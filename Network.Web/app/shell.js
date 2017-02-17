define(['plugins/http', 'plugins/router', 'knockout', './authenticate/manage'], function (http, router, ko, authenticate) {
    var viewmodel = {
        router: router,
        activate: function () {
            
            router.guardRoute = function (instance, instruction) {
                return true;
            }
           
            return router.map([
                { route: ['', 'home'], moduleId: 'home/view' },
                { route: ['home'], moduleId: 'home/view' },
            ]).buildNavigationModel()
              .mapUnknownRoutes('home/view')
              .activate();
        },
        displayMenu: function () {
            return router.activeInstruction().fragment !== 'login';
        }
    }
    return viewmodel;
});