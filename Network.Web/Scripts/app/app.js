var map;
var markers = [];
var infowindow;
var windowURL = window.URL || window.webkitURL;
$(function () {
    "use strict";
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
                if (moment(current, 'dd/mm/yyyy',true).isValid()) {
                   
                    var parsedDate = moment(value, 'DD/MM/YYYY').format('DD/MM/YYYY');
                    $(element).datepicker({
                      //  dateFormat: 'dd/mm/yyyy',
                        setDate: parsedDate
                    });
                   // $(element).text();
                    $(element).val(parsedDate);
                }else
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

        update: function (element, valueAccessor, allBindingsAccessor,viewmodel) {
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

    //ko extend google map
   
    ///*
    ko.bindingHandlers.map = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            var mapObj = ko.utils.unwrapObservable(valueAccessor());
            var latLng = new google.maps.LatLng(mapObj.LocationLatitude(), mapObj.LocationLongitude());
               
            var mapOptions = {
                center: latLng,
                zoom: 6,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };

            map = new google.maps.Map(element, mapOptions);            
            google.maps.event.addDomListener(window, 'load', function () {
                console.log('alert');
            });
            var marker = new google.maps.Marker({
                map: map,
                position: latLng,
                //title: "You Are Here",
                draggable: true
            });

            var basewindow = new google.maps.InfoWindow({
                content: "<div class='infoDiv'><h2>" + mapObj.LocationName() + "</div></div>"
            });
            var infowindow = basewindow;
            mapObj.onChangedCoord = function (newValue) {
                var latLng = new google.maps.LatLng(
                    ko.utils.unwrapObservable(mapObj.LocationLatitude()),
                    ko.utils.unwrapObservable(mapObj.LocationLongitude()));
                map.setCenter(latLng);
            };

            mapObj.onMarkerMoved = function (dragEnd) {
                var latLng = marker.getPosition();
                mapObj.LocationLatitude(latLng.lat());
                mapObj.LocationLongitude(latLng.lng());
            };

            mapObj.LocationLatitude.subscribe(mapObj.onChangedCoord);
            mapObj.LocationLongitude.subscribe(mapObj.onChangedCoord);

            google.maps.event.addDomListener(window, 'resize', function () {
                var center = map.getCenter();
                map.setCenter(center);
            });
            // And aditionally you can need use "trigger" for real responsive
            google.maps.event.trigger(map, "resize");

            google.maps.event.addListener(marker, 'dragend', mapObj.onMarkerMoved);
            google.maps.event.addListener(marker, 'click', function () {
                //open info window
                
                infowindow.open(map, mapObj.marker);
            });
            markers.push(marker);
            viewModel._mapMarker = marker;
           // $("#" + element.getAttribute("id")).data("mapObj", mapObj);
        },
        update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            /*
            
    */
    }
    };
    //*/
    ko.bindingHandlers.maps = {
       // /*  
        init: function (element, valueAccessor, allBindingsAccessor, viewModel) {

            markers = [];
            var mapObjs = ko.utils.unwrapObservable(valueAccessor());
                //ko.utils.unwrapObservable(valueAccessor());

            var latLng = new google.maps.LatLng(
                ko.utils.unwrapObservable(15.9857498),
                ko.utils.unwrapObservable(105.7729918));
           // 15.9857498, 105.7729918
            var mapOptions = {
                center: latLng,
                zoom: 5,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            //  map.googleMap = new google.maps.Map(element, mapOptions);
            map = new google.maps.Map(element, mapOptions);
            
            $.each(mapObjs, function (i, item) {
                var Latlng = new google.maps.LatLng(item.LocationLatitude(), item.LocationLongitude());
                console.log('x' + i + ': ' + item.LocationLatitude() + ' ' + item.LocationLongitude());

                var marker = new google.maps.Marker({
                    position: Latlng,
                    map: map,
                    title: item.LocationName(),
                    
                });
                 marker.setIcon('http://maps.google.com/mapfiles/ms/icons/blue-dot.png');



                markers.push(marker);

                var basewindow = new google.maps.InfoWindow({
                    content: "<div class='infoDiv'><h2>" + item.LocationName() + "</h2></div>"
                });
                infowindow = basewindow;
                google.maps.event.addListener(marker, 'click', function () {
                    //open info window
                    
                    if (infowindow) {
                        infowindow.close();
                    }                    
                    infowindow.open(map, item.marker);
                });
                google.maps.Map.prototype.clearMarkers = function () {                   
                    for (var i = 0; i < markers.length; i++)
                    { markers[i].setMap(null); }
                    markers.length = 0;
                };
                google.maps.Map.prototype.refreshMarkers = function () {
                    for (var i = 0; i < markers.length; i++)
                    { markers[i].setMap(map); }
                };
               

            });
            
        },
       // */
        
        update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
           
            var mapObj = ko.utils.unwrapObservable(valueAccessor());
            var latlng = new google.maps.LatLng(
                ko.utils.unwrapObservable(mapObj.lat),
                ko.utils.unwrapObservable(mapObj.lng));
            /*  
            viewModel._mapMarker.setPosition(latlng);

        if (viewModel.selected()) {
            viewModel._mapMarker.setIcon('../../Img/star_green.png');
            clearArr(stationMarkers);

            var stations = viewModel.parent.stations();
            var nearest = nearestStationsVM(viewModel.lat(), viewModel.lng(), 5, stations);
            addStationsToMap(nearest);


        } else {
            viewModel._mapMarker.setIcon('../../Img/star_red.png');
        }
         //  */
        }
    
    };
   // */
  
    //ko extend with https://gist.github.com/jasonhofer/d8d9f6d5feb160b9a28b
    ko.bindingHandlers.select2 = {
        init: function (element, valueAccessor, allBindingsAccessor) {
            var $el = $(element),
                options = valueAccessor() || {},
                bindings = allBindingsAccessor() || {};
            $el.select2(options);
            if (bindings.value && ko.isSubscribable(bindings.value)) {
                bindings.value.subscribe(function () {
                    $el.trigger('change');
                });
            }
            ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
                $el.select2('destroy');
            });
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
    p.postWithRedirect = function (url, paramsObj, controller,action ,Vasync) {
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