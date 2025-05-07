import { Ship } from './ship.model';
import { Port } from './port.model';

export interface Voyage {
  id: number;
  voyageDate: Date;
  startDate: Date;
  endDate: Date;
  ship: Ship;
  departurePort: Port;
  arrivalPort: Port;
}
