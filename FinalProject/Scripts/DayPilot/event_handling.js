function create(start, end, resource) {
    createModal().showUrl('../Timetable/NewEvent.aspx?start=' + start + "&end=" + end + "&resource=" + resource);
}

function edit(e) {
    createModal().showUrl('../Timetable/EditEvent.aspx?id=' + e.value());
}

function createModal() {
    var modal = new DayPilot.Modal();
    modal.top = 60;
    modal.width = 500;
    modal.opacity = 50;
    modal.border = "10px solid #d0d0d0";
    modal.closed = function () {
        if (this.result && this.result.refresh) {
            dp.commandCallBack("refresh", { message: this.result.message });
        }
        dp.clearSelection();
    };

    modal.setHeight = function (height) {
        modal.height = height;
        return modal;
    };

    modal.height = 260;
    modal.zIndex = 100;

    return modal;
}
