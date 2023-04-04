$(function () {

    var dataManager = ej.DataManager({
        url: "/api/Alumno",
        adaptor: new ej.WebApiAdaptor(),
        offline: true
    });

    var dataManagergrado = ej.DataManager({
        url: "/api/Grado",
        adaptor: new ej.WebApiAdaptor()
    });

    var dataManagerNota = ej.DataManager({
        url: "/api/Nota",
        adaptor: new ej.WebApiAdaptor()
    });

    dataManager.ready.done(function (e) {
        $("#Grid").ejGrid({
            dataSource: ej.DataManager({
                json: e.result,
                adaptor: new ej.remoteSaveAdaptor(),
                insertUrl: "/api/Alumno/Insert",
                updateUrl: "/api/Alumno/Update",
                removeUrl: "/api/Alumno/Remove",
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
                { field: "Codigo", headerText: 'Codigo', defaultValue: 0, validationRules: { required: true } },
                { field: "Nombre", headerText: 'Nombre', defaultValue: 0, validationRules: { required: true } },
                { field: "Apellido", headerText: 'Apellido', defaultValue: 0, validationRules: { required: true }},
                { field: "Direccion", headerText: 'Direccion', defaultValue: 0, validationRules: { required: true }  },
                { field: "Email", headerText: 'Email', defaultValue: 0, validationRules: { required: true } },
                { field: "Movil", headerText: 'Movil', defaultValue: 0, validationRules: { required: true }  },
                
                { field: "IdNota", headerText: 'Nota', foreignKeyField: "Id", foreignKeyValue: "Nombre", dataSource: dataManagerNota, validationRules: { required: true } },
                { field: "IdGrado", headerText: 'Grado', foreignKeyField: "Id", foreignKeyValue: "Nombre", dataSource: dataManagergrado, validationRules: { required: true } },
                { field: "Activo", headerText: 'Activo', type: "boolean", editType: "booleanedit" },

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
