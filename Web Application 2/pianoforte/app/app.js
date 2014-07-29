angular.module('curve-builder', [
  'ngAnimate',
  'ngSanitize',
  'ngGrid',
  'ng-context-menu',
  'ui.bootstrap',
  'ui.tree',
  'calc',
  'pascalprecht.translate',
  'tmh.dynamicLocale',
  'curve-builder-tpls'
])
  .config(['$httpProvider', '$translateProvider', 'tmhDynamicLocaleProvider', function ($httpProvider, $translateProvider, tmhDynamicLocaleProvider) {
    $httpProvider.interceptors.push('httpInterceptor');
    $translateProvider.useStaticFilesLoader({
      prefix: 'localization/',
      suffix: '.json'
    });
    $translateProvider.preferredLanguage('en');
    tmhDynamicLocaleProvider.localeLocationPattern('/Apps/calculatorng/file?angular-i18n/angular-locale_{{locale}}.js');
  }])
  .run(['$window', '$http', '$timeout', 'User', 'Localization', 'NProgress', function ($window, $http, $timeout, User, Localization, NProgress) {
    // Remove Eikon scrollbar
    $window.top.document.body.style.position = 'fixed';

    NProgress.configure({ showSpinner: false });
    User.init();

    // UserSettings service request slows down other request
    $timeout(function () {
      User.getSettings().success(function (userSettings) {
        Localization.set(userSettings['COMMON.REGIONAL_SETTINGS.UI_LANGUAGE'],
          userSettings['COMMON.REGIONAL_SETTINGS.NUMBERFORMAT_DECIMALSEPARATOR'],
          userSettings['COMMON.REGIONAL_SETTINGS.NUMBERFORMAT_GROUPSEPARATOR']);
      });
    }, 100);
  }]);
