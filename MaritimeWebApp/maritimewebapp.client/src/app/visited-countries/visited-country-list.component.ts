import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VisitedCountry } from '../models/visited-country.model';
import { VisitedCountryService } from '../services/visited-country.service';

@Component({
  selector: 'app-visited-country-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './visited-country-list.component.html'
})
export class VisitedCountryListComponent implements OnInit {
  countries: VisitedCountry[] = [];

  constructor(private visitedCountryService: VisitedCountryService) { }

  ngOnInit(): void {
    this.visitedCountryService.getAll().subscribe((data: VisitedCountry[]) => {
      this.countries = data;
    });
  }
}
