import { Component, Inject, OnInit, NgZone } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormBuilder } from '@angular/forms';
import { finalize, takeUntil, debounceTime } from 'rxjs/operators';
import * as _ from 'lodash';
import { LibraryService } from '../shared/library.service';
import { Book } from '../shared/book';
import { UpdateNotification } from '../shared/update-notification';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  loading: boolean;
  audiobooks: Book[];
  filteredAudiobooks: Book[];
  form: FormGroup;
  allSelected = false;
  connected = false;
  updateNotification: UpdateNotification;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private _fb: FormBuilder,
    private libraryService: LibraryService,
    private _ngZone: NgZone
  ) {
    this.subscribeToEvents();
    this.updateNotification = new UpdateNotification();
    this.updateNotification.complete = true;
  }

  ngOnInit() {
    this.form = this._fb.group({
      author: [''],
      album: [''],
      title: ['']
    });

    this.form.valueChanges.pipe(debounceTime(500)).subscribe(() => {
      this.filter();
    });

    // this.loadData();
  }

  private subscribeToEvents(): void {
    this.libraryService.connectionEstablished.subscribe(connected => {
      this.connected = connected;
      if (this.connected) {
        console.log('Getting books');
        this.loadData();
      }
    });

    this.libraryService.updateNotificationReceived.subscribe((update: UpdateNotification) => {
      this._ngZone.run(() => {
        this.updateNotification = update;
      });
    });
  }

  loadData() {
    this.loading = true;
    this.libraryService.getBooks().then(data => {
      this.audiobooks = data;
      this.filter();
      this.loading = false;
    });
    // this.loading = true;
    // this.http
    //   .get<Book[]>(this.baseUrl + 'api/Audiobooks')
    //   .pipe(
    //     finalize(() => {
    //       this.loading = false;
    //     })
    //   )
    //   .subscribe(
    //     result => {
    //       this.audiobooks = result;
    //       this.filter();
    //     },
    //     error => console.error(error)
    //   );
  }

  refreshData() {
    this.updateNotification.percent = 0;
    this.updateNotification.complete = false;
    this.libraryService.refreshLibrary();
    // this.loading = true;
    // this.http.post(this.baseUrl + 'api/Audiobooks/refresh', null).subscribe(
    //   result => {
    //     this.loading = false;
    //   },
    //   error => console.error(error)
    // );
  }

  filter() {
    const filterData = this.form.value;
    const that = this;
    this.filteredAudiobooks = _.filter(this.audiobooks, function(book) {
      if (that.checkData(book.author, filterData.author) && that.checkData(book.title, filterData.title) && that.checkData(book.album, filterData.album)) {
        return book;
      }
    });
  }

  checkData(arg1, arg2) {
    if (!arg1) {
      if (!arg2) {
        return true;
      }
    } else {
      return arg1.toLowerCase().includes(arg2.toLowerCase());
    }
  }

  filterBy(field, value) {
    this.form.controls[field].setValue(value);
  }

  selectAll() {}

  select(book) {
    // book.selected = true;
  }
}
