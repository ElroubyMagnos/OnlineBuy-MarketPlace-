"use strict";
var AllButtons = document.querySelectorAll('[data-list]');
for (var i = 0; i < AllButtons.length; i++) {
    var btn = AllButtons[i];
    var targetname = btn.dataset.list;
    var TargetDetect = document.querySelectorAll('.' + targetname);
    btn.addEventListener('click', function () {
        for (var j = 0; j < TargetDetect.length; j++) {
            var target = TargetDetect[j];
            target.style.display = target.style.display === 'block' ? 'none' : 'block';
        }
    });
}
var popup = document.createElement('div');
popup.className = 'popup';
document.body.appendChild(popup);
var imgopen = document.getElementsByClassName('open');
for (var i = 0; i < imgopen.length; i++) {
    imgopen[i].addEventListener('click', function (e) {
        console.log(e.target);
        popup.style.display = 'block';
        popup.innerHTML = '';
        popup.onclick = function () {
            popup.style.display = 'none';
        };
        popup.style.textAlign = 'center';
        var theclone = e.target.cloneNode(true);
        theclone.style.width = '75%';
        theclone.style.margin = '50px auto';
        popup.appendChild(theclone);
    });
}
