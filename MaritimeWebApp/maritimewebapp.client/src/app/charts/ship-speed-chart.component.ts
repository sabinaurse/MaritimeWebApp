import { Component, OnInit } from '@angular/core';
import { ShipService } from '../services/ship.service';
import { Ship } from '../models/ship.model';
import { ChartConfiguration } from 'chart.js';
import { CommonModule } from '@angular/common';
import { NgChartsModule } from 'ng2-charts';

@Component({
  selector: 'app-ship-speed-chart',
  standalone: true,
  imports: [CommonModule, NgChartsModule],
  templateUrl: './ship-speed-chart.component.html'
})
export class ShipSpeedChartComponent implements OnInit {
  ships: Ship[] = [];

  chartData: ChartConfiguration<'bar'>['data'] = {
    labels: [],
    datasets: []
  };

  constructor(private shipService: ShipService) { }

  ngOnInit(): void {
    this.shipService.getAll().subscribe(data => {
      this.ships = data;
      this.chartData = {
        labels: data.map(s => s.name),
        datasets: [
          {
            label: 'Max Speed (knots)',
            data: data.map(s => s.maxSpeed),
            backgroundColor: 'rgba(54, 162, 235, 0.6)',
            borderColor: 'rgba(54, 162, 235, 1)',
            borderWidth: 1
          }
        ]
      };
    });
  }
}
