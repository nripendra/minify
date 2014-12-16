minify
======

A simple winform program to minify js. Has the capability to listen for changes. Does bundling and minification depending upon the config file.

```Json
{
 "projectName": "Cubicle.js",
 "bundles": [{"bundleName": "Cubicle.min.js", "files": ["Cubicle.js"], "minify": true}]
}
```
Above example is from actual project "[Cubicle.js](https://github.com/nripendra/Cubicle.js/)". You will be able to combine (bundle) multiple js files into a single file, and also opt to minify the bundle too, pretty much similar to bundling and minification in asp.net mvc. You can also create multiple bundles if desired.  