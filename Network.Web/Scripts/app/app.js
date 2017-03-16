var map;
var mapSingle;
var mapEdit;
var markerInsert;
var markerEdit;
var infowindow;
var windowURL = window.URL || window.webkitURL;
$(function () {
    "use strict";

    // extends observable objects intelligently
    ko.utils.extendObservable = function (target, source) {
        var prop, srcVal, isObservable = false;

        for (prop in source) {

            if (!source.hasOwnProperty(prop)) {
                continue;
            }

            if (ko.isWriteableObservable(source[prop])) {
                isObservable = true;
                srcVal = source[prop]();
            } else if (typeof (source[prop]) !== 'function') {
                srcVal = source[prop];
            }

            if (ko.isWriteableObservable(target[prop])) {
                target[prop](srcVal);
            } else if (target[prop] === null || target[prop] === undefined) {

                target[prop] = isObservable ? ko.observable(srcVal) : srcVal;

            } else if (typeof (target[prop]) !== 'function') {
                target[prop] = srcVal;
            }

            isObservable = false;
        }
        return target;
    };

    ko.utils.clone = function (obj, emptyObj) {
        var json = ko.toJSON(obj);
        var js = JSON.parse(json);

        return ko.utils.extendObservable(emptyObj, js);
    };

    //http://stackoverflow.com/questions/6612705/jquery-ui-datepicker-change-event-not-caught-by-knockoutjs

    ko.bindingHandlers.datepicker = {
        init: function (element, valueAccessor, allBindingsAccessor) {
            //initialize datepicker with some optional options
            var options = allBindingsAccessor().datepickerOptions || {};

            var funcOnSelectdate = function () {
                var observable = valueAccessor();
                observable($(element).datepicker("getDate"));
            }

            options.onSelect = funcOnSelectdate;

            $(element).datepicker(options);

            //handle the field changing
            ko.utils.registerEventHandler(element, "change", funcOnSelectdate);

            //handle disposal (if KO removes by the template binding)
            ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
                $(element).datepicker("destroy");
            });

        },
        update: function (element, valueAccessor) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            if (value == null) {
                $(element).datepicker("setDate", null);
            } else {
                if (typeof (value) === "string") { // JSON string from server
                    value = value.split("T")[0]; // Removes time
                }

                var current = $(element).datepicker("getDate");
                if (moment(current, 'dd/mm/yyyy', true).isValid()) {

                    var parsedDate = moment(value, 'DD/MM/YYYY').format('DD/MM/YYYY');
                    $(element).datepicker({
                        //  dateFormat: 'dd/mm/yyyy',
                        setDate: parsedDate
                    });
                    // $(element).text();
                    $(element).val(parsedDate);
                } else
                    $(element).val(value);

            }


        }
    };

    ko.bindingHandlers.money = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            ko.utils.registerEventHandler(element, 'keyup', function (event) {
                var observable = valueAccessor();
                observable(element.value);
                observable(numeral().unformat(element.value));
                ko.applyBindingsToNode(element, {
                    text: observable
                });
            });
        },
        update: function (element, valueAccessor, allBindingsAccessor) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            value = numeral().unformat(value);
            value = value.toString().replace(/[^- + 0-9]+/g, '');
            $(element).val(value.toString().replace(/\d(?=(?:\d{3})+(?!\d))/g, '$&,'));
        }
    };

    ko.bindingHandlers.file = {
        init: function (element, valueAccessor) {
            $(element).change(function () {
                var file = this.files[0];
                if (ko.isObservable(valueAccessor())) {
                    valueAccessor()(file);
                }
            });
        },

        update: function (element, valueAccessor, allBindingsAccessor, viewmodel) {
            var file = ko.utils.unwrapObservable(valueAccessor());
            var bindings = allBindingsAccessor();

            if (bindings.fileObjectURL && ko.isObservable(bindings.fileObjectURL)) {
                var oldUrl = bindings.fileObjectURL();
                if (oldUrl) {
                    windowURL.revokeObjectURL(oldUrl);
                }
                //    bindings.fileObjectURL(file && windowURL.createObjectURL(file));
            }

            if (bindings.fileBinaryData && ko.isObservable(bindings.fileBinaryData)) {
                if (!file) {
                    bindings.fileBinaryData(null);
                } else {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        bindings.fileBinaryData(e.target.result);
                    };
                    //   reader.readAsArrayBuffer(file);
                }
            }
        }
    };

    ko.bindingHandlers.howManyDay = {
        update: function (element, valueAccessor) {
            var value = valueAccessor();
            var dayMonemnt = moment(value, 'DD/MM/YYYY');
            var day = 0;
            if (dayMonemnt._isValid) {
                day = dayMonemnt.diff(moment([]), 'days');
            }
            $(element).removeClass();           
            $(element).addClass(day <= 0? "label label-danger": "label label-primary");            
            $(element).text(day);
        }
    };
    //ko extend google map

    /*
    ko.bindingHandlers.map1 = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel) {

            var mapObj = ko.utils.unwrapObservable(valueAccessor());//;

            var model = allBindingsAccessor().model;
            var latLng;
            if (model().LocationLatitude() == undefined || model().LocationLatitude() === 0
                || model().LocationLongitude() == undefined || model().LocationLongitude() === 0)
                latLng = new google.maps.LatLng(15.9857498, 105.7729918);
            else
                latLng = new google.maps.LatLng(model().LocationLatitude(), model().LocationLongitude());

            google.maps.event.addDomListener(window, 'resize', function () {
                var center = mapObj.getCenter();
                mapObj.setCenter(center);
            });
            // And aditionally you can need use "trigger" for real responsive
            google.maps.event.trigger(mapObj, "resize");

            var marker = new google.maps.Marker({
                map: mapObj,
                position: latLng,
                //title: "You Are Here",
                draggable: true
            });
            mapObj.addListener('center_changed', function () {
                // 0.5 seconds after the center of the map has changed, pan back to the
                // marker.
                window.setTimeout(function () {
                    mapObj.panTo(marker.getPosition());
                }, 500);
            });
            mapObj.onChangedCoord = function (newValue) {
                var latLng = new google.maps.LatLng(
                    ko.utils.unwrapObservable(model().LocationLatitude()),
                    ko.utils.unwrapObservable(model().LocationLongitude()));
                mapObj.setCenter(latLng);
            };

            mapObj.onMarkerMoved = function (dragEnd) {
                var latLng = marker.getPosition();
                model().LocationLatitude(latLng.lat());
                model().LocationLongitude(latLng.lng());
            };
            model().LocationLatitude.subscribe(mapObj.onChangedCoord);
            model().LocationLongitude.subscribe(mapObj.onChangedCoord);

            google.maps.event.addListener(marker, 'dragend', mapObj.onMarkerMoved);

            viewModel._mapMarkerSingle = marker;

            /*
           

            
           

            


            
            //   markers.push(marker);
           

            // $("#" + element.getAttribute("id")).data("mapObj", mapObj);
            
        },
        update: function (element, valueAccessor, allBindingsAccessor, viewModel) {

            var mapObj = ko.utils.unwrapObservable(valueAccessor());
            var model = allBindingsAccessor().model;
            // /*
            var latLng;
            if (model().LocationLatitude() == undefined || model().LocationLatitude() === 0
                || model().LocationLongitude() == undefined || model().LocationLongitude() === 0)
                latLng = new google.maps.LatLng(11.956703866197335, 107.37699570625);
            else
                latLng = new google.maps.LatLng(model().LocationLatitude(), model().LocationLongitude());
            // model()._mapMarkerSingle.setMap(mapObj);
            viewModel._mapMarkerSingle.setPosition(latLng);
            viewModel._mapMarkerSingle.setIcon('Img/star_blue.png');
            //  mapObj
            
            //  map.setCenter(latLng);
            /*
            
    
        }
    };
    */
    ko.bindingHandlers.map = {
        // /*  
        init: function (element, valueAccessor, allBindingsAccessor, viewModel) {

            var isEdit = allBindingsAccessor().isEdit;
            var localMap = valueAccessor();
            var position = isEdit ? new google.maps.LatLng(allBindingsAccessor().latitude(), allBindingsAccessor().longitude()) : localMap.getCenter();
            var title = isEdit ? "isEdit" : '';
            var marker = new google.maps.Marker({
                map: localMap,
                position: position,
                icon: 'Img/star_red.png',
                title: title
            });
           
            localMap.addListener('center_changed', function () {
                // 0.5 seconds after the center of the map has changed, pan back to the
                // marker.
                window.setTimeout(function () {
                    localMap.panTo(marker.getPosition());
                }, 500);
            });

           

            if (isEdit) {
                viewModel.selectedDTO()._mapMarker = marker;
                markerEdit = marker;
            }

            else {
                markerInsert = marker;
                viewModel._mapMarker = marker;
            }

        },
        // */

        update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            var isEdit = allBindingsAccessor().isEdit;
            var localMap = valueAccessor();
            var position = allBindingsAccessor().latitude() !== 0 && allBindingsAccessor().longitude() !== 0 ? new google.maps.LatLng(allBindingsAccessor().latitude(), allBindingsAccessor().longitude()) : localMap.getCenter();
            if (isEdit) {
              //  viewModel.selectedDTO()._mapMarker.setPosition(position);
                markerEdit.setPosition(position);
                markerEdit.setIcon('Img/star_blue.png');
            } else {
                //  viewModel._mapMarker.setPosition(position);
                markerInsert.setPosition(position);
                markerInsert.setIcon('Img/star_blue.png');
            }

            
                //   viewModel._mapMarker.setIcon(null);
            
           
                //  viewModel._mapMarker.setMap(allBindingsAccessor().map);

            

        }

    };
    //*/
    ko.bindingHandlers.maps = {
        // /*  
        init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            var position = new google.maps.LatLng(allBindingsAccessor().latitude(), allBindingsAccessor().longitude());

            var marker = new google.maps.Marker({
                map: allBindingsAccessor().maps,
                position: position,
                icon: 'Icons/star.png',
                title: name
            });
            /*
            var basewindow = new google.maps.InfoWindow({
                content: "<div class='infoDiv'><h2>" + model().LocationName() + "</div></div>"
            });
            var infowindow = basewindow;
            */
            google.maps.event.addListener(marker, 'click', function () {
                // if(viewModel.)
                locationVM.select(viewModel);
                locationVM.report();
               // var test = viewModel;
                
            });


            
            viewModel._mapMarker = marker;
           
        },
        // */

        update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            var latlng = new google.maps.LatLng(allBindingsAccessor().latitude(), allBindingsAccessor().longitude());

            viewModel._mapMarker.setPosition(latlng);

            if (viewModel.selected()) {
                //   viewModel._mapMarker.setIcon(null);
                viewModel._mapMarker.setIcon('Img/star_blue.png');
                //  viewModel._mapMarker.setMap(allBindingsAccessor().map);

            } else {
                viewModel._mapMarker.setIcon('Img/star_red.png');
            }

        }

    };
    // */

    ko.bindingHandlers.iCheck = {
        init: function (element, valueAccessor) {
            $(element).iCheck({
                checkboxClass: "icheckbox_minimal-blue",
                radioClass: "iradio_minimal-blue"
            });

            $(element).on('ifChanged', function () {
                var observable = valueAccessor();
                observable($(element)[0].checked);
            });
        },
        update: function (element, valueAccessor) {
            var value = ko.unwrap(valueAccessor());
            if (value) {
                $(element).iCheck('check');
            } else {
                $(element).iCheck('uncheck');
            }
        }
    };
    //ko extend with https://github.com/codearachnid/knockout.extend/blob/03fac2da4d80f35601482730d3df3264945d062e/lib/bindingHandlers.select2.js
    ko.bindingHandlers.select2 = {
        init: function (el, valueAccessor, allBindingsAccessor, viewModel) {
            var bindingId = "#" + valueAccessor() + "";
            ko.utils.domNodeDisposal.addDisposeCallback(el, function () {
                $(el).select2('destroy');
            });
          //  $("#myModalCreate")
            $(el).select2({
                dropdownParent: $(bindingId)
            });
        },
        update: function(ele) {
        
        $(ele).trigger('change');
    }
    };
    //end 
    var Ultra = function () {
    };
    var p = Ultra.prototype;
    p.messageCreateOK = '';
    p.messageEditOK = "@Res.GlobalResource.Action_Edit_Success";
    p.handleRedirections = function (xhr) {
        if (xhr.status === 430) {
            window.location = xhr.responseJSON.redirectionUrl;
            return true;
        }
        return false;
    };

    p.handleTimeout = function (textStatus) {
        if (textStatus === "timeout") {
            toastr.error('Connection timeout !');
            return true;
        }
        return false;
    };
    p.postReturnValue = function (url, paramsObj, Vasync) {
        if (typeof Vasync === "undefined") {
            Vasync = true;
        }
        $.ajax({
            method: "POST",
            url: url,
            timeout: 7000,
            contentType: "application/json; charset=utf-8",
            async: Vasync,
            data: JSON.stringify(paramsObj)
        }).done(function (data) {
            return data;
        });;
    };
    p.postNoReturn = function (url, paramsObj, successMessage, Vasync) {
        if (typeof Vasync === "undefined") {
            Vasync = false;
        }
        return $.ajax({
            method: "POST",
            url: url,
            timeout: 7000,
            contentType: "application/json; charset=utf-8",
            async: Vasync,
            data: JSON.stringify(paramsObj)
        }).fail(function (xhr, textStatus) {
            var isHandled = p.handleRedirections(xhr)
                || p.handleTimeout(textStatus);
            if (!isHandled) {
                toastr.error("Action failed !.");
            }

        }).success(function (data) {
            if (data.ResponseCode === 1) {
                toastr.success(successMessage);
            }

        });
    };
    p.postWithRedirect = function (url, paramsObj, controller, action, Vasync) {
        if (typeof Vasync === "undefined") {
            Vasync = false;
        }

        return $.ajax({
            method: "POST",
            url: url,
            timeout: 7000,
            contentType: "application/json; charset=utf-8",
            async: Vasync,
            data: JSON.stringify(paramsObj)
        }).fail(function (xhr, textStatus) {
            var isHandled = p.handleRedirections(xhr)
                || p.handleTimeout(textStatus);
            if (!isHandled) {
                toastr.error("Action failed !.");
            }

        }).success(function (data) {
            if (data.ResponseCode === 1) {
                toastr.success(successMessage);
                window.location.href = '@Url.Action(action,controller)';
            }

        });
    };

    //defined namespace
    window.Ultra = new Ultra();
}());