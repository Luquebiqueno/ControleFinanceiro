import { Component, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { formatDate } from '@angular/common';
import { DashboardService } from 'src/app/services/dashboard.service';
import { Dashboard } from 'src/app/models/dashboard';
import * as am5 from '@amcharts/amcharts5';
import * as am5xy from '@amcharts/amcharts5/xy';
import am5themes_Animated from '@amcharts/amcharts5/themes/Animated';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

    form: FormGroup;
    totalGastos: number;
    totalGastoFixo: number;
    totalGastoVariavel: number;
    dashboard: Dashboard[];

    constructor(private fb: FormBuilder,
        private dashboardService: DashboardService,
        @Inject(LOCALE_ID) public locale: string) { }

    ngOnInit(): void {
        this.getForm();
        this.getDashboard();
    }

    getForm(): void {
        this.form = this.fb.group({
            dataInicial: new Date(new Date().setDate(new Date().getDate() - 120)),
            dataFinal: new Date()
        });
    }

    getDashboard() {
        let dataInicial = formatDate(this.form.value.dataInicial, 'dd-MM-yyyy', this.locale)
        let dataFinal = formatDate(this.form.value.dataFinal, 'dd-MM-yyyy', this.locale)

        this.dashboardService.getDashboard(dataInicial, dataFinal).subscribe((response: any) => {
            this.dashboard = response;

            this.totalGastoFixo = this.dashboard.map(x => x.gastoFixo).reduce((x, y) => {
                return x + y
            }, 0);

            this.totalGastoVariavel = this.dashboard.map(x => x.gastoVariavel).reduce((x, y) => {
                return x + y
            }, 0);

            this.totalGastos = this.totalGastoFixo + this.totalGastoVariavel;

            this.carregarGrafico();
        });
    }

    limpar() {
        this.getForm();
        this.getDashboard();
    }

    maybeDisposeRoot(divId: any) {
        am5.array.each(am5.registry.rootElements, function (root) {
            if (root.dom.id == divId) {
                root.dispose();
            }
        });
    };

    carregarGrafico() {
        this.maybeDisposeRoot("chartdiv")
        let root = am5.Root.new("chartdiv");

        root.setThemes([
            am5themes_Animated.new(root)
        ]);

        let chart = root.container.children.push(am5xy.XYChart.new(root, {
            panX: false,
            panY: false,
            wheelX: "panX",
            wheelY: "zoomX",
            layout: root.verticalLayout
        }));

        let legend = chart.children.push(
            am5.Legend.new(root, {
                centerX: am5.p50,
                x: am5.p50
            })
        );

        let data = this.dashboard;

        let xRenderer = am5xy.AxisRendererX.new(root, {
            cellStartLocation: 0.1,
            cellEndLocation: 0.9
        })

        let xAxis = chart.xAxes.push(am5xy.CategoryAxis.new(root, {
            categoryField: "mes",
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

        function makeSeries(name, fieldName) {
            let series = chart.series.push(am5xy.ColumnSeries.new(root, {
                name: name,
                xAxis: xAxis,
                yAxis: yAxis,
                valueYField: fieldName,
                categoryXField: "mes"
            }));

            series.columns.template.setAll({
                tooltipText: "{name}, {categoryX}:{valueY}",
                width: am5.percent(90),
                tooltipY: 0,
                strokeOpacity: 0
            });

            series.data.setAll(data);

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

        makeSeries("Gasto Fixo", "gastoFixo");
        makeSeries("Gasto Variável", "gastoVariavel");

        chart.appear(1000, 100);
    }
}
