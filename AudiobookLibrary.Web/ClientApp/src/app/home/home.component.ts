import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormBuilder } from '@angular/forms';
import { finalize, takeUntil, debounceTime } from 'rxjs/operators';
import * as _ from 'lodash';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  loading: boolean;
  audiobooks: AudiobookFile[];
  filteredAudiobooks: AudiobookFile[];
  form: FormGroup;
  allSelected = false;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private _fb: FormBuilder
  ) {}

  ngOnInit() {
    this.form = this._fb.group({
      author: [''],
      album: [''],
      title: ['']
    });

    this.form.valueChanges.pipe(debounceTime(500)).subscribe(() => {
      this.filter();
    });
    this.loadData();
  }

  loadData() {
    this.loading = true;
    this.http
      .get<AudiobookFile[]>(this.baseUrl + 'api/Audiobooks')
      .pipe(
        finalize(() => {
          this.loading = false;
        })
      )
      .subscribe(
        result => {
          this.audiobooks = result;
          this.filter();
        },
        error => console.error(error)
      );
  }

  refreshData() {
    this.loading = true;
    this.http.post(this.baseUrl + 'api/Audiobooks/refresh', null).subscribe(
      result => {
        this.loading = false;
      },
      error => console.error(error)
    );
  }

  filter() {
    const filterData = this.form.value;
    const that = this;
    this.filteredAudiobooks = _.filter(this.audiobooks, function(book) {
      if (
        that.checkData(book.author, filterData.author) &&
        that.checkData(book.title, filterData.title) &&
        that.checkData(book.album, filterData.album)
      ) {
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

interface AudiobookFile {
  audiobookFileId: number;
  title: string;
  author: string;
  album: string;
  disc: number | null;
  track: number | null;
  image: string;
  filename: string;
  selected: boolean;
}
