$(function () {

    var dataManager = ej.DataManager({
        url: "/api/Services",
        adaptor: new ej.WebApiAdaptor(),
        offline: true
    });

    var dataManagerGoodsReceivedNote = ej.DataManager({
        url: "/api/Comercios",
        adaptor: new ej.WebApiAdaptor()
    });

    dataManager.ready.done(function (e) {
        $("#Grid").ejGrid({
            dataSource: ej.DataManager({
                json: e.result,
                adaptor: new ej.remoteSaveAdaptor(),
                insertUrl: "/api/Services/Insert",
                updateUrl: "/api/Services/Update",
                removeUrl: "/api/Services/Remove",
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
                { field: "IdServicios", headerText: 'IdServicios', isPrimaryKey: true, isIdentity: true, visible: false },
                { field: "IdComercio", headerText: 'Comercio', foreignKeyField: "IdComercio", foreignKeyValue: "NomComercio", dataSource: dataManagerGoodsReceivedNote, validationRules: { required: true } },
                { field: "NomServicio", headerText: 'Nombre', validationRules: { required: true } },
                { field: "HoraApertura", headerText: 'Hora Inicio', validationRules: { required: true }},
                { field: "HoraCierre", headerText: 'Hora Fin', validationRules: { required: true } },
                { field: "Duracion", headerText: 'Duracion', validationRules: { required: true } },
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
