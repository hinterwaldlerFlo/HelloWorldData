import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'measuredValues',
    templateUrl: './measuredValues.component.html'
})
export class MeasuredValuesComponent {
    public data: MeasuredValues[];

    constructor(http: Http) {
        http.get('/api/WeatherForecasts').subscribe(result => {
            this.data = result.json() as MeasuredValues[];
        });
    }
}

interface MeasuredValues {
    Name: string;
    Timestamp: Date;
    Value: number;
}
