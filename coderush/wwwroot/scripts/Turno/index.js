$(function () {

    var dataManager = ej.DataManager({
        url: "/api/Turno",
        adaptor: new ej.WebApiAdaptor(),
        offline: true
    });

    var dataManagerGoodsReceivedNote = ej.DataManager({
        url: "/api/Services",
        adaptor: new ej.WebApiAdaptor()
    });

    dataManager.ready.done(function (e) {
        $("#Grid").ejGrid({
            dataSource: ej.DataManager({
                json: e.result,
                adaptor: new ej.remoteSaveAdaptor(),
                insertUrl: "/api/Turno/Insert",
                updateUrl: "/api/Turno/Update",
                removeUrl: "/api/Turno/Remove",
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
                { field: "IdTurno", headerText: 'IdTurno', isPrimaryKey: true, isIdentity: true, visible: false },
                { field: "IdServicio", headerText: 'Servicio', foreignKeyField: "IdServicios", foreignKeyValue: "NomServicio", dataSource: dataManagerGoodsReceivedNote, validationRules: { required: true } },
                { field: "FechaTurna", headerText: 'Fecha', editType: "datepicker", format: "{0:MM/dd/yyyy}", validationRules: { required: true }, validationRules: { required: true } },
                { field: "HoraInicio", headerText: 'Hora Inicio', defaultValue: 0},
                { field: "HoraFin", headerText: 'Hora Fin', defaultValue: 0 },
                { field: "Estado", headerText: 'Estado', type: "boolean", editType: "booleanedit" },
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
