requirejs.config({
    waitSeconds: 0,
    paths: {
        'text': '../lib/require/text',
        'durandal': '../lib/durandal/js',
        'plugins': '../lib/durandal/js/plugins',
        'transitions': '../lib/durandal/js/transitions',
        'knockout': '../lib/knockout/knockout-3.1.0',
        'komapping': '../lib/knockout/knockout.mapping',
        'bootstrap': '../lib/bootstrap/js/bootstrap',
        'jquery': '../lib/jquery/jquery-2.2.3.min',
        'toastr': '../lib/toastr/toastr.min',
        'linq': '../lib/jquery_plugins/jquery.linq.min',
        'chosen': '../lib/jquery_plugins/chosen/chosen.jquery.min',
        'moment': '../lib/jquery_plugins/moment.min',
        'AdminLTE': '../lib/AdminLTE/dist/js/app',
        
    },
    shim: {
        'AdminLTE': {
            deps: ['jquery'],
            exports: 'jQuery'
        },
        'bootstrap': {
            deps: ['jquery'],
            exports: 'jQuery'
        },       
        'toastr': {
            deps: ['jquery'],
            exports: 'toastr'
        },
        'linq': {
            deps: ['jquery'],
            exports: '$'
        },
       
        'chosen': {
            deps: ['jquery'],
            exports: '$'
        },
        'komapping': {
            deps: ['knockout'],
            exports: 'komapping'
        }  
    }
});
define(['durandal/system', 'durandal/app', 'durandal/viewLocator'], function ( system, app, viewLocator) {
    //>>excludeStart("build", true);
    system.debug(true);
    //>>excludeEnd("build");

    app.title = "Network Management";

    //specify which plugins to install and their configuration
    app.configurePlugins({
        router: true,
        dialog: true
    });

    app.start().then(function () {
        viewLocator.useConvention();
        app.setRoot('shell', 'entrance');
    });
});