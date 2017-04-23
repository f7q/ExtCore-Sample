var gulp = require("gulp");

gulp.task(
    "copy-extensions-debug", function (cb) {
        gulp.src(["../WebApplication.EFCoreRawQuery/bin/Debug/netstandard1.6/WebApplication.EFCoreRawQuery.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src(["../WebApplication.NLog/bin/Debug/netstandard1.6/WebApplication.NLog.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src(["../WebApplication.Elm/bin/Debug/netstandard1.6/WebApplication.Elm.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src(["../WebApplication.ExtensionA/bin/Debug/netstandard1.6/WebApplication.ExtensionA.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src(["../WebApplication.ExtensionB/bin/Debug/netstandard1.6/WebApplication.ExtensionB.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src(["../WebApplication.Script/bin/Debug/netstandard1.6/WebApplication.Script.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src(["../WebApplication.Swagger/bin/Debug/netstandard1.6/WebApplication.Swagger.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src(["../WebApplication.WebAPI/bin/Debug/netstandard1.6/WebApplication.WebAPI.dll"]).pipe(gulp.dest("Extensions"));
        cb();
    }
);

gulp.task(
    "copy-extensions-release", function (cb) {
        gulp.src(["../WebApplication.EFCoreRawQuery/bin/Release/netstandard1.6/WebApplication.EFCoreRawQuery.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src(["../WebApplication.NLog/bin/Release/netstandard1.6/WebApplication.NLog.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src(["../WebApplication.Elm/bin/Release/netstandard1.6/WebApplication.Elm.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src(["../WebApplication.ExtensionA/bin/Release/netstandard1.6/WebApplication.ExtensionA.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src(["../WebApplication.ExtensionB/bin/Release/netstandard1.6/WebApplication.ExtensionB.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src(["../WebApplication.Script/bin/Release/netstandard1.6/WebApplication.Script.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src(["../WebApplication.Swagger/bin/Release/netstandard1.6/WebApplication.Swagger.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src(["../WebApplication.WebAPI/bin/Release/netstandard1.6/WebApplication.WebAPI.dll"]).pipe(gulp.dest("Extensions"));
        cb();
    }
);