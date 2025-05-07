import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShipListComponent } from './ships/ship-list.component';
import { PortListComponent } from './ports/port-list.component';
import { VoyageListComponent } from './voyages/voyage-list.component';
import { VisitedCountryListComponent } from './visited-countries/visited-country-list.component';


const routes: Routes = [
  { path: 'ships', component: ShipListComponent },
  { path: 'ports', component: PortListComponent },
  { path: 'voyages', component: VoyageListComponent },
  { path: 'countries', component: VisitedCountryListComponent },
  { path: '', redirectTo: 'ships', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
