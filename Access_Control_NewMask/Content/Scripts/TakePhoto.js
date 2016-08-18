var photo = undefined;
var isChrome47 = false;
var hasWebcam = Webcam.userMedia || Webcam.detectFlash();
try {
    if (/Chrome/.test(navigator.userAgent) && /Google Inc/.test(navigator.vendor)) {
        isChrome47 = parseInt(navigator.userAgent.toLowerCase().split("chrome/")[1].substring(0, 2)) >= 47;
    }
}
catch (er) {
    console.log(er);
}
if (hasWebcam) {
    Webcam.set({
        width: 320,
        height: 320,
        dest_width: 400,
        dest_height: 480,
        image_format: 'jpeg',
        jpeg_quality: 100,
        force_flash: Webcam.detectFlash(),
        flip_horiz: false,
        fps: 45
    });
}
function AttachWebcam() {
    if (!hasWebcam) return;
    photo = undefined;
    Webcam.attach('#webcam');
}
function StopWebcam() {
    if (Webcam.loaded) {
        Webcam.reset();
    }
}
function take_snapshot() {
    if (!Webcam.loaded) return;
    Webcam.snap(function (data_uri) {
        document.getElementById('img').innerHTML = '<img src="' + data_uri + '"/>';
        $("#img").attr("src", data_uri);
        photo = data_uri;
        GetImageURl();
        return;
        Webcam.upload(data_uri, window.location, function (code, text) {
            console.log(code);
        });
    });
}
function UploadToServer() {
    if (!hasWebcam) return;
    Webcam.upload(photo, window.location, function (code, text) {
        console.log(code);
    });
}
function FreezeWebcam() {
    if (!Webcam.loaded) return;
    Webcam.freeze();
}
function UnFreezeWebcam() {
    if (!Webcam.loaded) return;
    Webcam.unfreeze();
}
function FlipWebcam() {
    if (!hasWebcam) return;
    Webcam.set({
        width: 320,
        height: 240,
        flip_horiz: true
    });
}
function AcceptPhoto() {
    if (!Webcam.loaded) return;
    take_snapshot();
}
function RemovePhoto() {
    photo = undefined;
    $("#img").attr("src", null);
}