import { Component, OnInit } from '@angular/core';
import { DateAdapter } from '@angular/material/core';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
    title = 'front';

    constructor(private _adapter: DateAdapter<any>) { }

    ngOnInit(): void {
        this.setLocale();
    }

    setLocale() {
        this._adapter.setLocale('pt-BR');
    }
}
