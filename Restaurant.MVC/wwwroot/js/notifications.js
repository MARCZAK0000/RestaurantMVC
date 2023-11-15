const currentScript = document.currentScript;
const type = currentScript.getAttribute('data-type');
const message = currentScript.getAttribute('data-currentMessage');

toastr[type](message);