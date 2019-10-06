export class UpdateNotification {
  count: number;
  filesComplete: number;
  percent: number;
  complete: boolean;

  public constructor(init?: Partial<UpdateNotification>) {
    Object.assign(this, init);
  }
}
