import { EventEmitter, Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { UpdateNotification } from './update-notification';

@Injectable({
  providedIn: 'root'
})
export class LibraryService {
  updateNotificationReceived = new EventEmitter<UpdateNotification>();
  connectionEstablished = new EventEmitter<Boolean>();
  private connectionIsEstablished = false;
  private _hubConnection: HubConnection;

  constructor() {
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection();
  }

  private createConnection() {
    this._hubConnection = new HubConnectionBuilder().withUrl('library').build();
  }

  private startConnection(): void {
    this._hubConnection
      .start()
      .then(() => {
        this.connectionIsEstablished = true;
        console.log('Hub connection started');
        this.connectionEstablished.emit(true);
      })
      .catch(err => {
        console.log('Error while establishing connection, retrying...');
        setTimeout(() => this.startConnection(), 5000);
      });
  }

  private registerOnServerEvents(): void {
    this._hubConnection.on('LibraryUpdate', (data: UpdateNotification) => {
      console.log(data);
      this.updateNotificationReceived.emit(data);
    });
    const that = this;
    this._hubConnection.onclose(() => {
      console.log('Hub connection lost');
      that.connectionIsEstablished = false;
      that.startConnection();
    });
  }

  getBooks() {
    return this._hubConnection.invoke('GetBooks');
  }

  refreshLibrary() {
    return this._hubConnection.invoke('RefreshLibrary');
  }
}
