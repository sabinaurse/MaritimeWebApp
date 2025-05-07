import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ShipService } from '../services/ship.service';
import { Ship } from '../models/ship.model';

@Component({
  selector: 'app-ship-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './ship-list.component.html',
  styleUrls: ['./ship-list.component.css']
})
export class ShipListComponent implements OnInit {
  ships: Ship[] = [];

  constructor(private shipService: ShipService) { }

  ngOnInit(): void {
    this.loadShips();
  }

  loadShips(): void {
    this.shipService.getAll().subscribe({
      next: data => this.ships = data,
      error: err => console.error('Eroare la încărcare nave:', err)
    });
  }
}
