"use strict";
class Dynamics {
    constructor() {
    }
    static stringIsNotValid(str) {
        return str.length === 0 || str === '' || str === undefined || str === null;
    }
    static refreshPage() {
        window.location.reload();
    }
    static goto(url) {
        window.location.replace(url);
    }
    static elementPosition(id) {
        var rect = document.getElementById(id)?.getBoundingClientRect();
        return { top: rect?.top, bottom: rect?.bottom, left: rect?.left, right: rect?.right };
    }
    static RemoveElement(container, Remove) {
        container.removeChild(Remove);
    }
    static RemoveFromArray(container, Remove) {
        for (var i = 0; i < container.length; i++) {
            if (container[i] === Remove) {
                container.splice(i, 1);
            }
        }
    }
}
class CSList {
    Content = [];
    constructor() {
    }
    Add(item) {
        if (!this.Content.includes(item))
            this.Content.push(item);
    }
    Remove(item) {
        for (var i = 0; i < this.Count(); i++) {
            if (this.Content[i] == item) {
                this.Content.splice(i, 1);
                break;
            }
        }
    }
    RemoveAt(index) {
        if (this.Count() > 0)
            this.Content.splice(index, 1);
    }
    Count() {
        return this.Content.length;
    }
}
class CSDictionary {
    Content = [[], []];
    constructor() {
    }
    get Keys() {
        let content = [];
        for (var i = 0; i < this.Content[0].length; i++) {
            content.push(this.Content[0][i]);
        }
        return content;
    }
    get Values() {
        let content = [];
        for (var i = 0; i < this.Content[1].length; i++) {
            content.push(this.Content[1][i]);
        }
        return content;
    }
    Add(Key, Value) {
        if (!this.Content[0].includes(Key)) {
            this.Content[0].push(Key);
            this.Content[1].push(Value);
        }
    }
    Remove(Key) {
        for (var i = 0; i < this.Content[0].length; i++) {
            if (this.Content[0][i] == Key) {
                this.Content[0].splice(i, 1);
                this.Content[1].splice(i, 1);
                break;
            }
        }
    }
    RemoveAt(index) {
        if (this.Count() > 0) {
            this.Content[0].splice(index, 1);
            this.Content[1].splice(index, 1);
        }
    }
    Count() {
        return this.Content[0].length;
    }
}
