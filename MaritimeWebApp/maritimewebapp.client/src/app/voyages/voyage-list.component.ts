import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Voyage } from '../models/voyage.model';
import { VoyageService } from '../services/voyage.service';

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
    this.voyageService.getAll().subscribe((data: Voyage[]) => this.voyages = data);
  }
}
