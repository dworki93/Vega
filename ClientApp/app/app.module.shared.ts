import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { VehiclesService } from './services/vehicles-service';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        VehicleFormComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: 'vehicles/new', component: VehicleFormComponent},
            { path: '', redirectTo: 'vehicles/new', pathMatch: 'full' },
            { path: '**', redirectTo: '' }
        ])
    ],
    providers: [
        VehiclesService
    ]
})
export class AppModuleShared {
}
