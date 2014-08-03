module.exports = function(grunt) {
	'use strict';

  require('load-grunt-tasks')(grunt);

	grunt.initConfig({
		meta: {
			app: 'app',			
			server: 'server',
      dist: 'dist',
      distapp: '<%= meta.dist %>/<%= meta.app %>',
			distserver: '<%= meta.dist %>/<%= meta.server %>',
      bower_components: '<%= meta.app %>/bower_components',
			pkg: grunt.file.readJSON('package.json'),
      banner: ['/*',
               ' * <%= meta.pkg.name %>',
               ' * Version: <%= meta.pkg.version %> - <%= grunt.template.today("yyyy-mm-dd") %>',
               ' */\n'].join('\n')
		},    

    clean: {
      common: ['<%= meta.dist %>', '<%= meta.app %>/**/*.html.js'],
      nonmin: ['<%= meta.distapp %>/*.js', '!<%= meta.distapp %>/*.min.js', '<%= meta.distapp %>/*.css', '!<%= meta.distapp %>/*.min.css']
    },

    concat: {
      options: {
        banner: '<%= meta.banner %>'
      },
      prejs: {
        src: '<%= dom_munger.data.prejs %>',
        dest: '<%= meta.distapp %>/pre.js'
      },
      appjs: {
        src: ['<%= meta.distapp %>/app.js', '<%= dom_munger.data.appjs %>'],
        dest: '<%= meta.distapp %>/app.js'
      },
      libjs: {
        src: '<%= dom_munger.data.libjs %>',
        dest: '<%= meta.distapp %>/lib.js'
      },
      libcss: {
        src: '<%= dom_munger.data.libcss %>',
        dest: '<%= meta.distapp %>/lib.css'
      }
    },

    copy: {
      dev: {
        files: [
          {
            expand: true,
            src: ['<%= meta.app %>/**', '!<%= meta.bower_components %>/**'],
            dest: '<%= meta.dist %>/',
            filter: 'isFile'
          },
          {
            expand: true,
            src: ['<%= meta.server %>/**'],
            dest: '<%= meta.dist %>/',
            filter: 'isFile'
          }
        ]
      },
      bower: {
        files: [
          {
            expand: true,
            src: ['<%= meta.bower_components %>/**'],
            dest: '<%= meta.dist %>/',
            filter: 'isFile'
          }
        ]
      }
    },

    cssmin: {
      dist: {
        options: {
          banner: '<%= meta.banner %>'
        },
        expand: true,
        cwd: '<%= meta.distapp %>/',
        src: ['**/*.css', '!bower_components/**'],
        dest: '<%= meta.distapp %>/',
        ext: '.min.css'
      }
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

    express: {
      options: {
        port: process.env.PORT || 9000
      },
      dev: {
        options: {
          script: '<%= meta.server %>/server.js',
          debug: true
        }
      },
      prod: {
        options: {
          script: '<%= meta.distserver %>/server.js'
        }
      }
    },

    less: {
    	dist: {
    		files: {
          '<%= meta.distapp %>/app.css': '<%= meta.app %>/app.less'
    		}
    	}
    },

    open: {
      server: {
        path : 'http://localhost:9000'
      }
    },

    watch: {
      css: {
        files: ['<%= meta.app %>/**/*.less'],
        tasks: ['buildcss'],
        options: {
          livereload: true,
        }
      },
      other: {
        files: ['<%= meta.app %>/**', '<%= meta.server %>/**', '!<%= meta.app %>/**/*.less'],
        tasks: ['copy:dev'],
        options: {
          livereload: true,
        }
      }
    }
  });

	grunt.registerTask('buildcss', ['less', 'cssmin']);
	grunt.registerTask('buildjs', ['test', 'dom_munger:dist', 'html2js:dist', 'concat', 'uglify']);
	// grunt.registerTask('check', ['jshint', 'jscs']);

  grunt.registerTask('dev', [
    'clean:common',
    'copy:dev',
    'copy:bower',
    'buildcss',
    // 'express:dev',
    'open',
    'watch'
  ]);
}