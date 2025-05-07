import { Voyage } from './voyage.model';

export interface VisitedCountry {
  id: number;
  countryName: string;
  visitDate: Date;
  voyage: Voyage;
  voyageId: number;
}
