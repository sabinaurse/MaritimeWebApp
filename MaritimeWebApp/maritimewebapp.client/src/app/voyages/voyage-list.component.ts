import { Component, OnInit } from '@angular/core';
import { Voyage } from '../models/voyage.model';
import { VoyageService } from '../services/voyage.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-voyage-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './voyage-list.component.html'
})
export class VoyageListComponent implements OnInit {
  voyages: Voyage[] = [];

  constructor(private voyageService: VoyageService) { }

  ngOnInit(): void {
    this.voyageService.getAll().subscribe({
      next: data => this.voyages = data,
      error: err => console.error('Error loading voyages:', err)
    });
  }
}
