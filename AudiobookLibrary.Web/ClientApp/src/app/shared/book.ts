import { Part } from './part';

export class Book {
  title: string;
  disc: number | null;
  image: boolean;
  selected: boolean;
  parts: Part[];
}
