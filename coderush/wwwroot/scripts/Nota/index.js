$(function () {

    var dataManager = ej.DataManager({
        url: "/api/Nota",
        adaptor: new ej.WebApiAdaptor(),
        offline: true
    });

   

    dataManager.ready.done(function (e) {
        $("#Grid").ejGrid({
            dataSource: ej.DataManager({
                json: e.result,
                adaptor: new ej.remoteSaveAdaptor(),
                insertUrl: "/api/Nota/Insert",
                updateUrl: "/api/Nota/Update",
                removeUrl: "/api/Nota/Remove",
            }),
            toolbarSettings: {
                showToolbar: true,
                toolbarItems: ["add", "edit", "delete", "update", "cancel", "search", "printGrid"]
            },
            editSettings: {
                allowEditing: true,
                allowAdding: true,
                allowDeleting: true,
                showDeleteConfirmDialog: true,
                editMode: "dialog"
            },
            isResponsive: true,
            enableResponsiveRow: true,
            allowSorting: true,
            allowSearching: true,
            allowFiltering: true,
            filterSettings: {
                filterType: "excel",
                maxFilterChoices: 100,
                enableCaseSensitivity: false
            },
            allowPaging: true,
            pageSettings: { pageSize: 10, printMode: ej.Grid.PrintMode.CurrentPage },
            columns: [
                { field: "Id", headerText: 'Id', isPrimaryKey: true, isIdentity: true, visible: false },
                { field: "Codigo", headerText: 'Codigo', validationRules: { required: true }},
                { field: "Nombre", headerText: 'Nombre', validationRules: { required: true }},
                { field: "Descripcion", headerText: 'Descripcion', defaultValue: 0},
        
                { field: "Activo", headerText: 'Estado', type: "boolean", editType: "booleanedit" },
            ],
            actionComplete: "complete",
        });
    });


});

function complete(args) {
    if (args.requestType == 'beginedit') {
        $("#" + this._id + "_dialogEdit").ejDialog({ title: "Edit Record" });
    }
}
