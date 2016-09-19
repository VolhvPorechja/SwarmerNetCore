var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    less = require('gulp-less'),
    browserSync = require('browser-sync').create(),
    header = require('gulp-header'),
    cleanCSS = require('gulp-clean-css'),
    rename = require("gulp-rename"),
    project = require("./project.json"),
    pkg = require('./package.json');

var paths = {
    webroot: "./" + project.webroot + "/"
};

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
    gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);

// Set the banner content
var banner = ['/*!\n',
    ' * Start Bootstrap - <%= pkg.title %> v<%= pkg.version %> (<%= pkg.homepage %>)\n',
    ' * Copyright 2013-' + (new Date()).getFullYear(), ' <%= pkg.author %>\n',
    ' * Licensed under <%= pkg.license.type %> (<%= pkg.license.url %>)\n',
    ' */\n',
    ''
].join('');

// Compile LESS files from /less into /css
gulp.task('less', function () {
    return gulp.src(paths.webroot + 'less/sb-admin-2.less')
        .pipe(less())
        .pipe(header(banner, { pkg: pkg }))
        .pipe(gulp.dest('dist/css'))
        .pipe(browserSync.reload({
            stream: true
        }));
});

// Minify compiled CSS
gulp.task('minify-css', ['less'], function () {
    return gulp.src(paths.webroot + 'dist/css/sb-admin-2.css')
        .pipe(cleanCSS({ compatibility: 'ie8' }))
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('dist/css'))
        .pipe(browserSync.reload({
            stream: true
        }));
});

// Copy JS to dist
gulp.task('js',
    function () {
        return gulp.src([paths.webroot + 'js/sb-admin-2.js'])
            .pipe(header(banner, { pkg: pkg }))
            .pipe(gulp.dest('dist/js'))
            .pipe(browserSync.reload({
                stream: true
            }));
    });

// Minify JS
gulp.task('minify-js', ['js'], function () {
    return gulp.src(paths.webroot + 'js/sb-admin-2.js')
        .pipe(uglify())
        .pipe(header(banner, { pkg: pkg }))
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('dist/js'))
        .pipe(browserSync.reload({
            stream: true
        }));
});

// Copy vendor libraries from /bower_components into /vendor
gulp.task('copy',
    function () {
        gulp.src([paths.webroot + 'bower_components/bootstrap/dist/**/*', '!**/npm.js', '!**/bootstrap-theme.*', '!**/*.map'])
            .pipe(gulp.dest(paths.webroot + 'vendor/bootstrap'));

        gulp.src([
                paths.webroot + 'bower_components/bootstrap-social/*.css', paths.webroot + 'bower_components/bootstrap-social/*.less',
                paths.webroot + 'bower_components/bootstrap-social/*.scss'
        ])
            .pipe(gulp.dest(paths.webroot + 'vendor/bootstrap-social'));

        gulp.src([paths.webroot + 'bower_components/datatables/media/**/*'])
            .pipe(gulp.dest(paths.webroot + 'vendor/datatables'));

        gulp.src([paths.webroot + 'bower_components/datatables-plugins/integration/bootstrap/3/*'])
            .pipe(gulp.dest(paths.webroot + 'vendor/datatables-plugins'));

        gulp.src([paths.webroot + 'bower_components/datatables-responsive/css/*', paths.webroot + 'bower_components/datatables-responsive/js/*'])
            .pipe(gulp.dest(paths.webroot + 'vendor/datatables-responsive'));

        gulp.src([paths.webroot + 'bower_components/flot/*.js'])
            .pipe(gulp.dest(paths.webroot + 'vendor/flot'));

        gulp.src([paths.webroot + 'bower_components/flot.tooltip/js/*.js'])
            .pipe(gulp.dest(paths.webroot + 'vendor/flot-tooltip'));

        gulp.src([
                paths.webroot + 'bower_components/font-awesome/**/*', '!' + paths.webroot + 'bower_components/font-awesome/*.json',
                '!' + paths.webroot + 'bower_components/font-awesome/.*'
        ])
            .pipe(gulp.dest(paths.webroot + 'vendor/font-awesome'));

        gulp.src([paths.webroot + 'bower_components/jquery/dist/jquery.js', paths.webroot + 'bower_components/jquery/dist/jquery.min.js'])
            .pipe(gulp.dest(paths.webroot + 'vendor/jquery'));

        gulp.src([paths.webroot + 'bower_components/metisMenu/dist/*'])
            .pipe(gulp.dest(paths.webroot + 'vendor/metisMenu'));

        gulp.src([
                paths.webroot + 'bower_components/morrisjs/*.js', paths.webroot + 'bower_components/morrisjs/*.css',
                '!' + paths.webroot + 'bower_components/morrisjs/Gruntfile.js'
        ])
            .pipe(gulp.dest(paths.webroot + 'vendor/morrisjs'));

        gulp.src([paths.webroot + 'bower_components/raphael/raphael.js', paths.webroot + 'bower_components/raphael/raphael.min.js'])
            .pipe(gulp.dest(paths.webroot + 'vendor/raphael'));

    });

// Run everything
gulp.task('default', ['minify-css', 'minify-js', 'copy']);

// Configure the browserSync task
gulp.task('browserSync', function () {
    browserSync.init({
        server: {
            baseDir: paths.webroot
        },
    })
})

// Dev task with browserSync
gulp.task('dev', ['browserSync', 'less', 'minify-css', 'js', 'minify-js'], function () {
    gulp.watch(paths.webroot + 'less/*.less', ['less']);
    gulp.watch(paths.webroot + 'dist/css/*.css', ['minify-css']);
    gulp.watch(paths.webroot + 'js/*.js', ['minify-js']);
    // Reloads the browser whenever HTML or JS files change
    gulp.watch(paths.webroot + 'pages/*.html', browserSync.reload);
    gulp.watch(paths.webroot + 'dist/js/*.js', browserSync.reload);
});