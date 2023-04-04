var Anno = [];
var Valor = [];
var rest = drawChart();
var datachart = {
    data: [],
    labels: []

}
function drawChart() {
    var resp;
    $.ajax({
        type: "GET",
        url: "/Grafico/GetGrafico",
        async: false,
        contentType: "application/json",
        success: function (data) {
            Anno = data[0];
            Valor = data[0];

            for (var i = 0; data.length - 1; i++) {

                datachart.labels.push(data[i].Anno);
                datachart.data.push(data[i].Valor);
            }


            $("#container").ejChart(
                {
                    //Initializing Primary X Axis
                    primaryXAxis:
                    {
                        axisLine: { visible: false },
                        majorGridLines: { visible: false },
                        majorTickLines: { visible: false },
                        range: { min: 1900, max: 2000, interval: 10 },
                        title: { text: 'Year' }
                    },

                    //Initializing Primary Y Axis
                    primaryYAxis:
                    {
                        axisLine: { visible: false },
                        majorTickLines: { visible: false },
                        range: { min: 2, max: 5, interval: 0.5 },
                        title: { text: 'Sales Amount in Millions' }
                    },

                    //Initializing Series	
                    series:
                        [
                            {
                                points: [{ x: datachart.labels, y: datachart.Valor }],
                                name: 'Product A',
                                type: 'Area',
                                enableAnimation: true,
                                border: { color: 'transparent' },
                                opacity: 0.5,
                                fill: '#69D2E7'
                            }
                        ],
                    load: "loadTheme",
                    isResponsive: true,
                    title: { text: 'Average Sales Comparison' },
                    size: { height: "600" },
                    legend: { visible: true }
                });
                resp.push(data);

        },
        error: function (response) {
            alert(response.responseText);
        },
        failure: function (response) {
            alert(response.responseText);
        }
       
    });
    return resp;
}

//$.getJSON("/Grafico/GetGrafico", function (data) {
  
    
//});



