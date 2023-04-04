$(function () {

    var dataManager = ej.DataManager({
        url: "/api/Comercios",
        adaptor: new ej.WebApiAdaptor(),
        offline: true
    });

    dataManager.ready.done(function (e) {
        $("#Grid").ejGrid({
            dataSource: ej.DataManager({
                json: e.result,
                adaptor: new ej.remoteSaveAdaptor(),
                insertUrl: "/api/Comercios/Insert",
                updateUrl: "/api/Comercios/Update",
                removeUrl: "/api/Comercios/Remove",
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
                { field: "IdComercio", headerText: 'IdComercio', isPrimaryKey: true, isIdentity: true, visible: false },

                { field: "NomComercio", headerText: 'Nombre', validationRules: { required: true } },
                { field: "AfprpMaximo", headerText: 'AfprpMaximo', },
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
