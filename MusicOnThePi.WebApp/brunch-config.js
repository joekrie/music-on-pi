exports.paths = {
    public: 'wwwroot',
    watched: ['ClientApp']
};

exports.files = {
  javascripts: {
    joinTo: {
      'vendor.js': /^(?!ClientApp)/,
      'app.js': /^ClientApp/
    }
  },
  stylesheets: {joinTo: 'app.css'}
};

exports.plugins = {
    babel: {
        presets: ['latest', 'react']
    }
};

exports.modules = {
  nameCleaner: path => path.replace(/^ClientApp\//, '')
};
