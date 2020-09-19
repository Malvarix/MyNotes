export class Note {
  constructor(
    public id?: number,
    public description?: string,
    public priority?: Priority ) { }
}

enum Priority{
  Low = 0,
  Intermediate = 1,
  High = 2
}
