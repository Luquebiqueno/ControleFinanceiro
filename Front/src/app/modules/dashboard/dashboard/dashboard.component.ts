import { Component, OnInit } from '@angular/core';
import * as am5 from '@amcharts/amcharts5';
import * as am5xy from '@amcharts/amcharts5/xy';
import am5themes_Animated from '@amcharts/amcharts5/themes/Animated';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

    constructor() { }

    ngOnInit(): void {
        this.initbarSort();
    }

    carregarGrafico() {
        /* Chart code */
        // Create root element
        // https://www.amcharts.com/docs/v5/getting-started/#Root_element
        let root = am5.Root.new("chartdiv");


        // Set themes
        // https://www.amcharts.com/docs/v5/concepts/themes/
        root.setThemes([
            am5themes_Animated.new(root)
        ]);


        // Create chart
        // https://www.amcharts.com/docs/v5/charts/xy-chart/
        let chart = root.container.children.push(am5xy.XYChart.new(root, {
            panX: false,
            panY: false,
            wheelX: "panX",
            wheelY: "zoomX",
            layout: root.verticalLayout
        }));


        // Add legend
        // https://www.amcharts.com/docs/v5/charts/xy-chart/legend-xy-series/
        let legend = chart.children.push(
            am5.Legend.new(root, {
                centerX: am5.p50,
                x: am5.p50
            })
        );

        let data = [{
            "year": "2021",
            "europe": 2.5,
            "namerica": 2.5,
            "asia": 2.1,
            "lamerica": 1,
            "meast": 0.8,
            "africa": 0.4
        }, {
            "year": "2022",
            "europe": 2.6,
            "namerica": 2.7,
            "asia": 2.2,
            "lamerica": 0.5,
            "meast": 0.4,
            "africa": 0.3
        }, {
            "year": "2023",
            "europe": 2.8,
            "namerica": 2.9,
            "asia": 2.4,
            "lamerica": 0.3,
            "meast": 0.9,
            "africa": 0.5
        }]


        // Create axes
        // https://www.amcharts.com/docs/v5/charts/xy-chart/axes/
        let xRenderer = am5xy.AxisRendererX.new(root, {
            cellStartLocation: 0.1,
            cellEndLocation: 0.9
        })

        let xAxis = chart.xAxes.push(am5xy.CategoryAxis.new(root, {
            categoryField: "year",
            renderer: xRenderer,
            tooltip: am5.Tooltip.new(root, {})
        }));

        xRenderer.grid.template.setAll({
            location: 1
        })

        xAxis.data.setAll(data);

        let yAxis = chart.yAxes.push(am5xy.ValueAxis.new(root, {
            renderer: am5xy.AxisRendererY.new(root, {
                strokeOpacity: 0.1
            })
        }));


        // Add series
        // https://www.amcharts.com/docs/v5/charts/xy-chart/series/
        function makeSeries(name, fieldName) {
            let series = chart.series.push(am5xy.ColumnSeries.new(root, {
                name: name,
                xAxis: xAxis,
                yAxis: yAxis,
                valueYField: fieldName,
                categoryXField: "year"
            }));

            series.columns.template.setAll({
                tooltipText: "{name}, {categoryX}:{valueY}",
                width: am5.percent(90),
                tooltipY: 0,
                strokeOpacity: 0
            });

            series.data.setAll(data);

            // Make stuff animate on load
            // https://www.amcharts.com/docs/v5/concepts/animations/
            series.appear();

            series.bullets.push(function () {
                return am5.Bullet.new(root, {
                    locationY: 0,
                    sprite: am5.Label.new(root, {
                        text: "{valueY}",
                        fill: root.interfaceColors.get("alternativeText"),
                        centerY: 0,
                        centerX: am5.p50,
                        populateText: true
                    })
                });
            });

            legend.data.push(series);
        }

        makeSeries("Europe", "europe");
        makeSeries("North America", "namerica");
        makeSeries("Asia", "asia");
        makeSeries("Latin America", "lamerica");
        makeSeries("Middle East", "meast");
        makeSeries("Africa", "africa");


        // Make stuff animate on load
        // https://www.amcharts.com/docs/v5/concepts/animations/
        chart.appear(1000, 100);
    }

    initbarSort(){
        let root = am5.Root.new("chartbarSort");
      
        // let root = am5.Root.new("chartdiv");
      
      
        // Set themes
        // https://www.amcharts.com/docs/v5/concepts/themes/
        root.setThemes([
          am5themes_Animated.new(root)
        ]);
        
        
        // Create chart
        // https://www.amcharts.com/docs/v5/charts/xy-chart/
        let chart = root.container.children.push(am5xy.XYChart.new(root, {
          panX: true,
          panY: true,
          wheelX: "none",
          wheelY: "none"
        }));
        
        // We don't want zoom-out button to appear while animating, so we hide it
        chart.zoomOutButton.set("forceHidden", true);
        
        
        // Create axes
        // https://www.amcharts.com/docs/v5/charts/xy-chart/axes/
        let xRenderer = am5xy.AxisRendererX.new(root, {
          minGridDistance: 30
        });
        xRenderer.labels.template.setAll({
          rotation: -90,
          centerY: am5.p50,
          centerX: 0,
          paddingRight: 15
        });
        xRenderer.grid.template.set("visible", false);
        
        let xAxis = chart.xAxes.push(am5xy.CategoryAxis.new(root, {
          maxDeviation: 0.3,
          categoryField: "country",
          renderer: xRenderer
        }));
        
        let yAxis = chart.yAxes.push(am5xy.ValueAxis.new(root, {
          maxDeviation: 0.3,
          min: 0,
          renderer: am5xy.AxisRendererY.new(root, {})
        }));
        
        
        // Add series
        // https://www.amcharts.com/docs/v5/charts/xy-chart/series/
        let series :any = chart.series.push(am5xy.ColumnSeries.new(root, {
          name: "Series 1",
          xAxis: xAxis,
          yAxis: yAxis,
          valueYField: "value",
          categoryXField: "country"
        }));
        
        // Rounded corners for columns
        series.columns.template.setAll({
          cornerRadiusTL: 5,
          cornerRadiusTR: 5
        });
        
        // Make each column to be of a different color
        series.columns.template.adapters.add("fill", function (fill, target) {
          return chart.get("colors").getIndex(series.columns.indexOf(target ));
        });
        
        series.columns.template.adapters.add("stroke", function (stroke, target) {
          return chart.get("colors").getIndex(series.columns.indexOf(target ));
        });
        
        // Add Label bullet
        series.bullets.push(function () {
          return am5.Bullet.new(root, {
            locationY: 1,
            sprite: am5.Label.new(root, {
              text: "{valueYWorking.formatNumber('#.')}",
              fill: root.interfaceColors.get("alternativeText"),
              centerY: 0,
              centerX: am5.p50,
              populateText: true
            })
          });
        });
        
        
        // Set data
        let data = [{
          "country": "USA",
          "value": 2025
        }, {
          "country": "China",
          "value": 1882
        }, {
          "country": "Japan",
          "value": 1809
        }, {
          "country": "Germany",
          "value": 1322
        }, {
          "country": "UK",
          "value": 1122
        }, {
          "country": "France",
          "value": 1114
        }, {
          "country": "India",
          "value": 984
        }, {
          "country": "Spain",
          "value": 711
        }, {
          "country": "Netherlands",
          "value": 665
        }, {
          "country": "Russia",
          "value": 580
        }, {
          "country": "South Korea",
          "value": 443
        }, {
          "country": "Canada",
          "value": 441
        }];
        
        xAxis.data.setAll(data);
        series.data.setAll(data);
        
        // update data with random values each 1.5 sec
        /*setInterval(function () {
          updateData();
        }, 1500)
        
        function updateData() {
          am5.array.each(series.dataItems, function (dataItem) {
            let value  = this.dataItem.get("valueY") + Math.round(Math.random() * 300 - 150);
            if (value < 0) {
              value = 10;
            }
            // both valueY and workingValueY should be changed, we only animate workingValueY
           this.dataItem.set("valueY", value);
            this.dataItem.animate({
              key: "valueYWorking",
              to: value,
              duration: 600,
              easing: am5.ease.out(am5.ease.cubic)
            });
          })
        
          sortCategoryAxis();
        }*/
        
        
        // Get series item by category
        function getSeriesItem(category) {
          for (var i = 0; i < series.dataItems.length; i++) {
            let dataItem = series.dataItems[i];
            if (dataItem.get("categoryX") == category) {
              return dataItem;
            }
          }
        }
        
        
        // Axis sorting
        function sortCategoryAxis() {
        
          // Sort by value
          series.dataItems.sort(function (x, y) {
            return y.get("valueY") - x.get("valueY"); // descending
            //return y.get("valueY") - x.get("valueY"); // ascending
          })
        
          // Go through each axis item
          am5.array.each(xAxis.dataItems, function (dataItem) {
            // get corresponding series item
            let seriesDataItem = getSeriesItem(dataItem.get("category"));
        
            if (seriesDataItem) {
              // get index of series data item
              let index = series.dataItems.indexOf(seriesDataItem);
              // calculate delta position
              let deltaPosition = (index - dataItem.get("index", 0)) / series.dataItems.length;
              // set index to be the same as series data item index
              dataItem.set("index", index);
              // set deltaPosition instanlty
              dataItem.set("deltaPosition", -deltaPosition);
              // animate delta position to 0
              dataItem.animate({
                key: "deltaPosition",
                to: 0,
                duration: 1000,
                easing: am5.ease.out(am5.ease.cubic)
              })
            }
          });
        
          // Sort axis items by index.
          // This changes the order instantly, but as deltaPosition is set,
          // they keep in the same places and then animate to true positions.
          xAxis.dataItems.sort(function (x, y) {
            return x.get("index") - y.get("index");
          });
        }
        
        
        // Make stuff animate on load
        // https://www.amcharts.com/docs/v5/concepts/animations/
        series.appear(1000);
        chart.appear(1000, 100);
        
    }
}
