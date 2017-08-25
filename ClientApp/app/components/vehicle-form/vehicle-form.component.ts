import { Component, OnInit } from '@angular/core';
import { Form } from "@angular/forms";
import { VehiclesService } from './../../services/vehicles-service';
import { Feature } from './../../../models/feature';
import { Make } from './../../../models/make';
import { Model } from './../../../models/model';
import { Vehicle } from './../../../models/vehicle';


@Component({
    selector: 'vehicle-form',
    templateUrl: 'vehicle-form.component.html'
})

export class VehicleFormComponent implements OnInit {
    makes = new Array<Make>();
    features = new Array<Feature>();
    form: Form;
    models = new Array<Model>();
    vehicle = new Vehicle();

    constructor(private _vehiclesService: VehiclesService)  { }

    ngOnInit() {
        this._vehiclesService.getMakes()
            .subscribe(makes => this.makes = makes);

        this._vehiclesService.getFeatures()
            .subscribe(features => this.features = features);
    }

    onMakeChange() {
        const selectedMake = this.makes
            .find(m => m.id == this.vehicle.make);

        this.models = selectedMake ? selectedMake.models : new Array<Model>();
    }

    onFeatureChange(featureId: number) {
        const featureIndex = this.vehicle.features
            .findIndex(feature => feature == featureId);

        if (featureIndex > -1) {
            this.vehicle.features.splice(featureIndex, 1);
        } else {
            this.vehicle.features.push(featureId);
        }
    }
}