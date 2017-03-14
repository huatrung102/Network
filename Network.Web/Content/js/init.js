$(function () {
    


    var config = {
        '.chosen-select': {},
        '.chosen-select-deselect': { allow_single_deselect: true },
        '.chosen-select-no-single': { disable_search_threshold: 10 },
        '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
        '.chosen-select-width': { width: "95%" }
    }
    //for (var selector in config) {
   //     $(selector).chosen(config[selector]);
    //  }
   // $("select").select2();
        //('destroy').select2().trigger('change');
  //  $("select").chosen({ width: "inherit" });
    /*
    
   

    $(".datepicker").datepicker({
        autoclose: true,
        dateFormat: 'dd/mm/yyyy'
    });
     */
    //$('input[type="checkbox"], input[type="radio"]').iCheck({
    //    checkboxClass: "icheckbox_minimal-blue",
    //    radioClass: "iradio_minimal-blue"
    //});

   // $("#datemask").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
    $("#datemask2").inputmask("mm/dd/yyyy", { "placeholder": "mm/dd/yyyy" });
    $("[data-mask]").inputmask();
});