module.exports = function(grunt) {
	'use strict';

	grunt.initConfig({
		meta: {
			app: 'app',
			dist: 'dist',
			server: 'server',
			distapp: '<%= meta.dist %>/<%= meta.app %>',
			pkg: grunt.file.readJSON('package.json'),
		},    

		dom_munger: {
      dist: {
        options: {
          read:[
            {
              selector: '[data-build="appjs"]',
              attribute: 'src',
              writeto: 'appjs',
              isPath: true
            }, {
              selector: '[data-build="libjs"]',
              attribute: 'src',
              writeto: 'libjs',
              isPath: true
            }, {
              selector: '[data-build="libcss"]',
              attribute: 'href',
              writeto: 'libcss',
              isPath: true
            }
          ],
          remove: ['[data-build]'],
          prepend: [
            {
              selector: 'body',
              html: [
                '<script src="pre.min.js"></script>',
                '\n'].join('\n')
            }
          ],
          append: [
            {
              selector: 'body',
              html: [
                '<link rel="stylesheet" href="lib.min.css">',
                '<link rel="stylesheet" href="app.min.css">',
                '<script src="lib.min.js"></script>',
                '<script src="app.min.js"></script>',
                '\n'].join('\n')
            }
          ]
        },
        src: '<%= meta.app %>/app.html',
        dest: '<%= meta.distapp %>/app.html'
      }
    },

		jscs: {
      options: {
        config: '.jscsrc'
      },
      app: {
        src: ['<%= meta.app %>/**/*.js', '!<%= meta.app %>/**/*.html.js', '!<%= meta.bower_components %>/**']
      },
      server: {
        src: ['<%= meta.server %>/**/*.js']
      }
    },

    jshint: {
      app: {
        options: {
          jshintrc: '<%= meta.app %>/.jshintrc'
        },
        src: ['<%= meta.app %>/**/*.js', '!<%= meta.app %>/**/*.html.js', '!<%= meta.bower_components %>/**']
      },
      server: {
        options: {
          jshintrc: '<%= meta.server %>/.jshintrc'
        },
        src: ['<%= meta.server %>/**/*.js']
      }
    },

    less: {
    	dist: {
    		files: {
    			'<%= meta.distapp %>/app.css': '<%= meta.app %>/app.less'
    		}
    	}
    }
  });

	grunt.registerTask('buildcss', ['less']);
	grunt.registerTask('buildjs', ['test', 'dom_munger:dist', 'html2js:dist', 'concat', 'uglify']);
	grunt.registerTask('check', ['jshint', 'jscs']);

  grunt.registerTask('dev', [])
}