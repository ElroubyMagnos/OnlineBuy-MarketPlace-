"use strict";
class Slider {
    imagpaths;
    interval;
    img;
    AddButtons;
    currentindex = 0;
    btncontainer = document.createElement('div');
    setint;
    ShowBtns() {
        document.querySelector('.btncontainer').style.display = 'block';
    }
    RemoveBtns() {
        document.querySelector('.btncontainer').style.display = 'none';
    }
    StartSliding() {
        this.setint = setInterval(() => {
            this.img.src = this.imagpaths[this.currentindex];
            this.currentindex++;
            if (this.currentindex === this.imagpaths.length) {
                this.currentindex = 0;
            }
            for (var i = 0; i < this.imagpaths.length; i++) {
                if (i === this.currentindex) {
                    this.btncontainer.children[i].style.backgroundColor = 'blue';
                }
                else {
                    this.btncontainer.children[i].style.backgroundColor = 'black';
                }
            }
        }, this.interval);
    }
    StopSliding() {
        clearInterval(this.setint);
    }
    constructor(imagpaths, interval, img, AddButtons) {
        this.imagpaths = imagpaths;
        this.interval = interval;
        this.img = img;
        this.AddButtons = AddButtons;
        var setint = this.setint;
        img.src = imagpaths[0];
        this.StartSliding();
        if (AddButtons) {
            this.btncontainer.className = 'btncontainer';
            var btncontainer = this.btncontainer;
            for (var i = 0; i < imagpaths.length; i++) {
                var btn = document.createElement('button');
                btn.className = 'sliderbtn';
                btn.textContent = (i + 1) + '';
                btn.addEventListener('click', function () {
                    clearInterval(setint);
                    for (var i = 0; i < imagpaths.length; i++) {
                        if (btncontainer.children[i] === this) {
                            btncontainer.children[i].style.backgroundColor = 'blue';
                            img.src = imagpaths[i];
                        }
                        else {
                            btncontainer.children[i].style.backgroundColor = 'black';
                        }
                    }
                });
                this.btncontainer.appendChild(btn);
                this.btncontainer.children[0].style.backgroundColor = 'blue';
            }
            img.parentNode?.insertBefore(this.btncontainer, img.nextSibling);
        }
    }
}
var alertdiv = document.createElement('div');
alertdiv.className = 'alertpopup';
var containerdiv = document.createElement('div');
containerdiv.className = 'cont';
var closebtn = document.createElement('button');
closebtn.innerText = 'X';
closebtn.className = 'closebtn';
var HeadPanel = document.createElement('div');
HeadPanel.className = 'header';
HeadPanel.appendChild(closebtn);
containerdiv.appendChild(HeadPanel);
var ta = document.createElement('textarea');
ta.className = 'textarea';
ta.setAttribute('readonly', '');
alertdiv.appendChild(containerdiv);
document.body.appendChild(alertdiv);
containerdiv.appendChild(ta);
closebtn.onclick = () => {
    alertdiv.style.display = 'none';
};
function ProAlert(Message) {
    ta.value = Message;
    alertdiv.style.display = alertdiv.style.display === 'block' ? 'none' : 'block';
}
