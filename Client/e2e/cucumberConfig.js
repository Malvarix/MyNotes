exports.config = {
  directConnect : true,
  getPagetimeout: 50000,
  allScriptsTimeout: 50000,
  framework: 'custom',
  frameworkPath: require.resolve('protactor-cucumber-framework'),
  capabilities: {
    'browserName' : 'chrome'
  },
  specs: [
    'tests/cucumber/Feature/home.feature'
  ],
  cucumberOpts: {
    require: 'tests/cucumber/StepDefination/homeSteps.js',
    tags: false,
    profile: false,
    'no-source': true
  }
};
