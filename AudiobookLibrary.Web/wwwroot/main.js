(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./node_modules/raw-loader/dist/cjs.js!./src/app/app.component.html":
/*!**************************************************************************!*\
  !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/app.component.html ***!
  \**************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<body>\r\n  <div class=\"container\">\r\n    <router-outlet></router-outlet>\r\n  </div>\r\n</body>\r\n");

/***/ }),

/***/ "./node_modules/raw-loader/dist/cjs.js!./src/app/home/home.component.html":
/*!********************************************************************************!*\
  !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/home/home.component.html ***!
  \********************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<div class=\"loading\" *ngIf=\"loading\">\r\n  <mat-spinner></mat-spinner>\r\n</div>\r\n<div *ngIf=\"!loading\">\r\n  <div *ngIf=\"updateNotification.complete\">\r\n    <a [routerLink]=\"\" (click)=\"refreshData()\">Refresh</a>\r\n  </div>\r\n  <div *ngIf=\"!updateNotification.complete\">\r\n    <mat-progress-bar [mode]=\"updateNotification.count ? 'determinate' : 'indeterminate'\"\r\n      [value]=\"updateNotification.percent\"></mat-progress-bar>\r\n    <div *ngIf=\"updateNotification.count\" class=\"count\">\r\n      {{updateNotification.filesComplete}} out of {{updateNotification.count}}\r\n    </div>\r\n  </div>\r\n\r\n  <div *ngFor=\"let bookSeries of series\">\r\n    <mat-card>\r\n      <mat-card-header>\r\n        <div mat-card-avatar class=\"header-image\" [style.backgroundImage]=\"'url('+ bookSeries.image +')'\"></div>\r\n        <mat-card-title>{{bookSeries.name}}</mat-card-title>\r\n        <mat-card-subtitle>{{bookSeries.author}}</mat-card-subtitle>\r\n      </mat-card-header>\r\n      <!-- <img mat-card-image [src]=\"bookSeries.image\"> -->\r\n      <mat-card-content>\r\n        <mat-accordion>\r\n          <mat-expansion-panel>\r\n            <mat-expansion-panel-header>\r\n              <mat-panel-title>\r\n                Books\r\n              </mat-panel-title>\r\n            </mat-expansion-panel-header>\r\n            <div class=\"book\" *ngFor=\"let book of bookSeries.books\">\r\n              <img [src]=\"book.image\" *ngIf=\"book.image\" />\r\n              <h4>{{book.title}}</h4>\r\n              <p><span *ngIf=\"book.disc> 0\">Book {{book.disc}}</span><span *ngIf=\"book.track> 0\">, Part\r\n                  {{book.track}}</span></p>\r\n            </div>\r\n            <!-- <mat-list>\r\n              <mat-list-item *ngFor=\"let book of bookSeries.books\">\r\n                <img matListAvatar [src]=\"book.image\" *ngIf=\"book.image\" />\r\n                <h4 mat-line>{{book.title}}</h4>\r\n                <p matLine><span *ngIf=\"book.disc> 0\">Book {{book.disc}}</span><span *ngIf=\"book.track> 0\">, Part\r\n                    {{book.track}}</span></p>\r\n                  </mat-list-item>\r\n                </mat-list> -->\r\n            <!-- <i [href]=\"'api/Audiobooks/download/' + encodeForUrl(book.filename)\"><i class=\"material-icons\">cloud_download</i></a> -->\r\n          </mat-expansion-panel>\r\n        </mat-accordion>\r\n      </mat-card-content>\r\n    </mat-card>\r\n  </div>\r\n  <!-- <form [formGroup]=\"form\" novalidate>\r\n    <table class=\"table\">\r\n      <thead>\r\n        <tr>\r\n          <th>\r\n            <input type=\"checkbox\" [checked]=\"allSelected\" />\r\n          </th>\r\n          <th></th>\r\n          <th>\r\n            <mat-form-field class=\"example-full-width\">\r\n              <input matInput type=\"text\" placeholder=\"Author\" formControlName=\"author\" />\r\n            </mat-form-field>\r\n          </th>\r\n          <th>\r\n            <mat-form-field class=\"example-full-width\">\r\n              <input matInput type=\"text\" placeholder=\"Title\" formControlName=\"title\" />\r\n            </mat-form-field>\r\n          </th>\r\n          <th>\r\n            <mat-form-field class=\"example-full-width\">\r\n              <input matInput type=\"text\" placeholder=\"Album\" formControlName=\"album\" />\r\n            </mat-form-field>\r\n          </th>\r\n          <th>Disc</th>\r\n          <th>Track</th>\r\n          <th></th></tr>\r\n      </thead>\r\n      <tbody>\r\n        <tr *ngFor=\"let audiobook of filteredAudiobooks\">\r\n          <td></td>\r\n          <td>\r\n            <img [src]=\"audiobook.image\" *ngIf=\"audiobook.image\" />\r\n          </td>\r\n          <td><a [routerLink]=\"\" (click)=\"filterBy('author', audiobook.author)\">{{audiobook.author}}</a></td>\r\n          <td><a [routerLink]=\"\" (click)=\"filterBy('title', audiobook.title)\">{{audiobook.title}}</a></td>\r\n          <td><a [routerLink]=\"\" (click)=\"filterBy('album', audiobook.album)\">{{audiobook.album}}</a></td>\r\n          <td>{{audiobook.disc}}</td>\r\n          <td>{{audiobook.track}}</td>\r\n          <td><a [href]=\"'api/Audiobooks/download/' + encodeForUrl(audiobook.filename)\">{{audiobook.filename}}</a></td>\r\n        </tr>\r\n      </tbody>\r\n    </table>\r\n  </form> -->\r\n</div>\r\n");

/***/ }),

/***/ "./src/$$_lazy_route_resource lazy recursive":
/*!**********************************************************!*\
  !*** ./src/$$_lazy_route_resource lazy namespace object ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./src/app/app.component.scss":
/*!************************************!*\
  !*** ./src/app/app.component.scss ***!
  \************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("@media (max-width: 767px) {\n  /* On small screens, the nav menu spans the full width of the screen. Leave a space for it. */\n  .body-content {\n    padding-top: 50px;\n  }\n}\n.container {\n  height: 100%;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvQzpcXERldlxcQXVkaW9ib29rTGlicmFyeVxcQXVkaW9ib29rTGlicmFyeS5XZWJcXENsaWVudEFwcC9zcmNcXGFwcFxcYXBwLmNvbXBvbmVudC5zY3NzIiwic3JjL2FwcC9hcHAuY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFFRSw2RkFBQTtFQUNBO0lBQ0UsaUJBQUE7RUNBRjtBQUNGO0FER0E7RUFDRSxZQUFBO0FDREYiLCJmaWxlIjoic3JjL2FwcC9hcHAuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyJAbWVkaWEgKG1heC13aWR0aDogNzY3cHgpIHtcclxuXHJcbiAgLyogT24gc21hbGwgc2NyZWVucywgdGhlIG5hdiBtZW51IHNwYW5zIHRoZSBmdWxsIHdpZHRoIG9mIHRoZSBzY3JlZW4uIExlYXZlIGEgc3BhY2UgZm9yIGl0LiAqL1xyXG4gIC5ib2R5LWNvbnRlbnQge1xyXG4gICAgcGFkZGluZy10b3A6IDUwcHg7XHJcbiAgfVxyXG59XHJcblxyXG4uY29udGFpbmVyIHtcclxuICBoZWlnaHQ6IDEwMCU7XHJcbn1cclxuIiwiQG1lZGlhIChtYXgtd2lkdGg6IDc2N3B4KSB7XG4gIC8qIE9uIHNtYWxsIHNjcmVlbnMsIHRoZSBuYXYgbWVudSBzcGFucyB0aGUgZnVsbCB3aWR0aCBvZiB0aGUgc2NyZWVuLiBMZWF2ZSBhIHNwYWNlIGZvciBpdC4gKi9cbiAgLmJvZHktY29udGVudCB7XG4gICAgcGFkZGluZy10b3A6IDUwcHg7XG4gIH1cbn1cbi5jb250YWluZXIge1xuICBoZWlnaHQ6IDEwMCU7XG59Il19 */");

/***/ }),

/***/ "./src/app/app.component.ts":
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __importDefault = (undefined && undefined.__importDefault) || function (mod) {
  return (mod && mod.__esModule) ? mod : { "default": mod };
};

var AppComponent = /** @class */ (function () {
    function AppComponent() {
        this.title = 'app';
    }
    AppComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-root',
            template: __importDefault(__webpack_require__(/*! raw-loader!./app.component.html */ "./node_modules/raw-loader/dist/cjs.js!./src/app/app.component.html")).default,
            styles: [__importDefault(__webpack_require__(/*! ./app.component.scss */ "./src/app/app.component.scss")).default]
        })
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! exports provided: AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/__ivy_ngcc__/fesm5/platform-browser.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/__ivy_ngcc__/fesm5/forms.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/__ivy_ngcc__/fesm5/http.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/__ivy_ngcc__/fesm5/router.js");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");
/* harmony import */ var _home_home_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./home/home.component */ "./src/app/home/home.component.ts");
/* harmony import */ var _shared_library_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./shared/library.service */ "./src/app/shared/library.service.ts");
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/platform-browser/animations */ "./node_modules/@angular/platform-browser/__ivy_ngcc__/fesm5/animations.js");
/* harmony import */ var _angular_material_input__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/material/input */ "./node_modules/@angular/material/__ivy_ngcc__/esm5/input.es5.js");
/* harmony import */ var _angular_material_progress_spinner__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! @angular/material/progress-spinner */ "./node_modules/@angular/material/__ivy_ngcc__/esm5/progress-spinner.es5.js");
/* harmony import */ var _angular_material_progress_bar__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! @angular/material/progress-bar */ "./node_modules/@angular/material/__ivy_ngcc__/esm5/progress-bar.es5.js");
/* harmony import */ var _angular_material_card__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! @angular/material/card */ "./node_modules/@angular/material/__ivy_ngcc__/esm5/card.es5.js");
/* harmony import */ var _angular_material_expansion__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! @angular/material/expansion */ "./node_modules/@angular/material/__ivy_ngcc__/esm5/expansion.es5.js");
/* harmony import */ var _angular_material_list__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! @angular/material/list */ "./node_modules/@angular/material/__ivy_ngcc__/esm5/list.es5.js");
/* harmony import */ var _angular_material_icon__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! @angular/material/icon */ "./node_modules/@angular/material/__ivy_ngcc__/esm5/icon.es5.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __importDefault = (undefined && undefined.__importDefault) || function (mod) {
  return (mod && mod.__esModule) ? mod : { "default": mod };
};
















var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            declarations: [_app_component__WEBPACK_IMPORTED_MODULE_5__["AppComponent"], _home_home_component__WEBPACK_IMPORTED_MODULE_6__["HomeComponent"]],
            imports: [
                _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"].withServerTransition({ appId: 'ng-cli-universal' }),
                _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HttpClientModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormsModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_2__["ReactiveFormsModule"],
                _angular_material_input__WEBPACK_IMPORTED_MODULE_9__["MatInputModule"],
                _angular_material_progress_spinner__WEBPACK_IMPORTED_MODULE_10__["MatProgressSpinnerModule"],
                _angular_material_progress_bar__WEBPACK_IMPORTED_MODULE_11__["MatProgressBarModule"],
                _angular_material_card__WEBPACK_IMPORTED_MODULE_12__["MatCardModule"],
                _angular_material_expansion__WEBPACK_IMPORTED_MODULE_13__["MatExpansionModule"],
                _angular_material_list__WEBPACK_IMPORTED_MODULE_14__["MatListModule"],
                _angular_material_icon__WEBPACK_IMPORTED_MODULE_15__["MatIconModule"],
                _angular_router__WEBPACK_IMPORTED_MODULE_4__["RouterModule"].forRoot([{ path: '', component: _home_home_component__WEBPACK_IMPORTED_MODULE_6__["HomeComponent"], pathMatch: 'full' }]),
                _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_8__["BrowserAnimationsModule"]
            ],
            providers: [_shared_library_service__WEBPACK_IMPORTED_MODULE_7__["LibraryService"]],
            bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_5__["AppComponent"]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "./src/app/home/home.component.scss":
/*!******************************************!*\
  !*** ./src/app/home/home.component.scss ***!
  \******************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = (":host {\n  margin-top: 20px;\n}\n\n.loading {\n  display: flex;\n  justify-content: center;\n  flex-direction: column;\n  text-align: center;\n  align-items: center;\n  height: 100%;\n}\n\n.count {\n  text-align: center;\n}\n\n.header-image {\n  background-size: cover;\n}\n\n.mat-card {\n  margin-top: 10px;\n}\n\n.mat-card-avatar,\n.mat-list-base .mat-list-item .mat-list-avatar {\n  width: 80px;\n  height: 80px;\n  border-radius: 3px;\n}\n\n.mat-list-base .mat-list-item .mat-list-item-content,\n.mat-list-base .mat-list-option .mat-list-item-content {\n  padding: 0;\n}\n\n.mat-list-item {\n  margin-top: 15px;\n}\n\n.mat-card-content {\n  margin-top: 10px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvaG9tZS9DOlxcRGV2XFxBdWRpb2Jvb2tMaWJyYXJ5XFxBdWRpb2Jvb2tMaWJyYXJ5LldlYlxcQ2xpZW50QXBwL3NyY1xcYXBwXFxob21lXFxob21lLmNvbXBvbmVudC5zY3NzIiwic3JjL2FwcC9ob21lL2hvbWUuY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDRSxnQkFBQTtBQ0NGOztBREVBO0VBQ0UsYUFBQTtFQUNBLHVCQUFBO0VBQ0Esc0JBQUE7RUFDQSxrQkFBQTtFQUNBLG1CQUFBO0VBQ0EsWUFBQTtBQ0NGOztBREVBO0VBQ0Usa0JBQUE7QUNDRjs7QURFQTtFQUNFLHNCQUFBO0FDQ0Y7O0FERUE7RUFDRSxnQkFBQTtBQ0NGOztBREdBOztFQUVFLFdBQUE7RUFDQSxZQUFBO0VBQ0Esa0JBQUE7QUNBRjs7QURHQTs7RUFFRSxVQUFBO0FDQUY7O0FER0E7RUFDRSxnQkFBQTtBQ0FGOztBREdBO0VBQ0UsZ0JBQUE7QUNBRiIsImZpbGUiOiJzcmMvYXBwL2hvbWUvaG9tZS5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIjpob3N0IHtcclxuICBtYXJnaW4tdG9wOiAyMHB4O1xyXG59XHJcblxyXG4ubG9hZGluZyB7XHJcbiAgZGlzcGxheTogZmxleDtcclxuICBqdXN0aWZ5LWNvbnRlbnQ6IGNlbnRlcjtcclxuICBmbGV4LWRpcmVjdGlvbjogY29sdW1uO1xyXG4gIHRleHQtYWxpZ246IGNlbnRlcjtcclxuICBhbGlnbi1pdGVtczogY2VudGVyO1xyXG4gIGhlaWdodDogMTAwJTtcclxufVxyXG5cclxuLmNvdW50IHtcclxuICB0ZXh0LWFsaWduOiBjZW50ZXI7XHJcbn1cclxuXHJcbi5oZWFkZXItaW1hZ2Uge1xyXG4gIGJhY2tncm91bmQtc2l6ZTogY292ZXI7XHJcbn1cclxuXHJcbi5tYXQtY2FyZCB7XHJcbiAgbWFyZ2luLXRvcDogMTBweDtcclxufVxyXG5cclxuXHJcbi5tYXQtY2FyZC1hdmF0YXIsXHJcbi5tYXQtbGlzdC1iYXNlIC5tYXQtbGlzdC1pdGVtIC5tYXQtbGlzdC1hdmF0YXIge1xyXG4gIHdpZHRoOiA4MHB4O1xyXG4gIGhlaWdodDogODBweDtcclxuICBib3JkZXItcmFkaXVzOiAzcHg7XHJcbn1cclxuXHJcbi5tYXQtbGlzdC1iYXNlIC5tYXQtbGlzdC1pdGVtIC5tYXQtbGlzdC1pdGVtLWNvbnRlbnQsXHJcbi5tYXQtbGlzdC1iYXNlIC5tYXQtbGlzdC1vcHRpb24gLm1hdC1saXN0LWl0ZW0tY29udGVudCB7XHJcbiAgcGFkZGluZzogMDtcclxufVxyXG5cclxuLm1hdC1saXN0LWl0ZW0ge1xyXG4gIG1hcmdpbi10b3A6IDE1cHg7XHJcbn1cclxuXHJcbi5tYXQtY2FyZC1jb250ZW50IHtcclxuICBtYXJnaW4tdG9wOiAxMHB4O1xyXG59XHJcbiIsIjpob3N0IHtcbiAgbWFyZ2luLXRvcDogMjBweDtcbn1cblxuLmxvYWRpbmcge1xuICBkaXNwbGF5OiBmbGV4O1xuICBqdXN0aWZ5LWNvbnRlbnQ6IGNlbnRlcjtcbiAgZmxleC1kaXJlY3Rpb246IGNvbHVtbjtcbiAgdGV4dC1hbGlnbjogY2VudGVyO1xuICBhbGlnbi1pdGVtczogY2VudGVyO1xuICBoZWlnaHQ6IDEwMCU7XG59XG5cbi5jb3VudCB7XG4gIHRleHQtYWxpZ246IGNlbnRlcjtcbn1cblxuLmhlYWRlci1pbWFnZSB7XG4gIGJhY2tncm91bmQtc2l6ZTogY292ZXI7XG59XG5cbi5tYXQtY2FyZCB7XG4gIG1hcmdpbi10b3A6IDEwcHg7XG59XG5cbi5tYXQtY2FyZC1hdmF0YXIsXG4ubWF0LWxpc3QtYmFzZSAubWF0LWxpc3QtaXRlbSAubWF0LWxpc3QtYXZhdGFyIHtcbiAgd2lkdGg6IDgwcHg7XG4gIGhlaWdodDogODBweDtcbiAgYm9yZGVyLXJhZGl1czogM3B4O1xufVxuXG4ubWF0LWxpc3QtYmFzZSAubWF0LWxpc3QtaXRlbSAubWF0LWxpc3QtaXRlbS1jb250ZW50LFxuLm1hdC1saXN0LWJhc2UgLm1hdC1saXN0LW9wdGlvbiAubWF0LWxpc3QtaXRlbS1jb250ZW50IHtcbiAgcGFkZGluZzogMDtcbn1cblxuLm1hdC1saXN0LWl0ZW0ge1xuICBtYXJnaW4tdG9wOiAxNXB4O1xufVxuXG4ubWF0LWNhcmQtY29udGVudCB7XG4gIG1hcmdpbi10b3A6IDEwcHg7XG59Il19 */");

/***/ }),

/***/ "./src/app/home/home.component.ts":
/*!****************************************!*\
  !*** ./src/app/home/home.component.ts ***!
  \****************************************/
/*! exports provided: HomeComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HomeComponent", function() { return HomeComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/__ivy_ngcc__/fesm5/http.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/__ivy_ngcc__/fesm5/forms.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! lodash */ "./node_modules/lodash/lodash.js");
/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_4___default = /*#__PURE__*/__webpack_require__.n(lodash__WEBPACK_IMPORTED_MODULE_4__);
/* harmony import */ var _shared_library_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../shared/library.service */ "./src/app/shared/library.service.ts");
/* harmony import */ var _shared_update_notification__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../shared/update-notification */ "./src/app/shared/update-notification.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (undefined && undefined.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
var __importDefault = (undefined && undefined.__importDefault) || function (mod) {
  return (mod && mod.__esModule) ? mod : { "default": mod };
};







var HomeComponent = /** @class */ (function () {
    function HomeComponent(http, baseUrl, _fb, libraryService, _ngZone) {
        this.http = http;
        this.baseUrl = baseUrl;
        this._fb = _fb;
        this.libraryService = libraryService;
        this._ngZone = _ngZone;
        this.allSelected = false;
        this.connected = false;
        this.subscribeToEvents();
        this.updateNotification = new _shared_update_notification__WEBPACK_IMPORTED_MODULE_6__["UpdateNotification"]({
            complete: true,
            filesComplete: 0,
            count: 0,
            percent: 0
        });
    }
    HomeComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.form = this._fb.group({
            author: [''],
            album: [''],
            title: ['']
        });
        this.form.valueChanges.pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["debounceTime"])(500)).subscribe(function () {
            _this.filter();
        });
        // this.loadData();
    };
    HomeComponent.prototype.subscribeToEvents = function () {
        var _this = this;
        this.libraryService.connectionEstablished.subscribe(function (connected) {
            _this.connected = connected;
            if (_this.connected) {
                _this.loadData();
            }
        });
        this.libraryService.updateNotificationReceived.subscribe(function (update) {
            _this._ngZone.run(function () {
                _this.updateNotification = update;
            });
        });
    };
    HomeComponent.prototype.loadData = function () {
        var _this = this;
        this.loading = true;
        this.libraryService.getBooks().then(function (data) {
            _this.series = data;
            // this.filter();
            _this.loading = false;
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
    };
    HomeComponent.prototype.refreshData = function () {
        this.updateNotification.percent = 0;
        this.updateNotification.count = 0;
        this.updateNotification.complete = false;
        this.libraryService.refreshLibrary();
        // this.loading = true;
        // this.http.post(this.baseUrl + 'api/Audiobooks/refresh', null).subscribe(
        //   result => {
        //     this.loading = false;
        //   },
        //   error => console.error(error)
        // );
    };
    HomeComponent.prototype.filter = function () {
        var filterData = this.form.value;
        var that = this;
        this.filteredAudiobooks = lodash__WEBPACK_IMPORTED_MODULE_4__["filter"](this.audiobooks, function (book) {
            if (that.checkData(book.author, filterData.author) && that.checkData(book.title, filterData.title) && that.checkData(book.album, filterData.album)) {
                return book;
            }
        });
    };
    HomeComponent.prototype.checkData = function (arg1, arg2) {
        if (!arg1) {
            if (!arg2) {
                return true;
            }
        }
        else {
            return arg1.toLowerCase().includes(arg2.toLowerCase());
        }
    };
    HomeComponent.prototype.filterBy = function (field, value) {
        this.form.controls[field].setValue(value);
    };
    HomeComponent.prototype.selectAll = function () { };
    HomeComponent.prototype.select = function (book) {
        // book.selected = true;
    };
    HomeComponent.prototype.encodeForUrl = function (data) {
        return encodeURIComponent(data);
    };
    HomeComponent.ctorParameters = function () { return [
        { type: _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"] },
        { type: String, decorators: [{ type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["Inject"], args: ['BASE_URL',] }] },
        { type: _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormBuilder"] },
        { type: _shared_library_service__WEBPACK_IMPORTED_MODULE_5__["LibraryService"] },
        { type: _angular_core__WEBPACK_IMPORTED_MODULE_0__["NgZone"] }
    ]; };
    HomeComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-home',
            template: __importDefault(__webpack_require__(/*! raw-loader!./home.component.html */ "./node_modules/raw-loader/dist/cjs.js!./src/app/home/home.component.html")).default,
            styles: [__importDefault(__webpack_require__(/*! ./home.component.scss */ "./src/app/home/home.component.scss")).default]
        }),
        __param(1, Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Inject"])('BASE_URL')),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"], String, _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormBuilder"],
            _shared_library_service__WEBPACK_IMPORTED_MODULE_5__["LibraryService"],
            _angular_core__WEBPACK_IMPORTED_MODULE_0__["NgZone"]])
    ], HomeComponent);
    return HomeComponent;
}());



/***/ }),

/***/ "./src/app/shared/library.service.ts":
/*!*******************************************!*\
  !*** ./src/app/shared/library.service.ts ***!
  \*******************************************/
/*! exports provided: LibraryService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LibraryService", function() { return LibraryService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm5/core.js");
/* harmony import */ var _aspnet_signalr__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @aspnet/signalr */ "./node_modules/@aspnet/signalr/dist/esm/index.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __importDefault = (undefined && undefined.__importDefault) || function (mod) {
  return (mod && mod.__esModule) ? mod : { "default": mod };
};


var LibraryService = /** @class */ (function () {
    function LibraryService() {
        this.updateNotificationReceived = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
        this.connectionEstablished = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
        this.connectionIsEstablished = false;
        this.createConnection();
        this.registerOnServerEvents();
        this.startConnection();
    }
    LibraryService.prototype.createConnection = function () {
        this._hubConnection = new _aspnet_signalr__WEBPACK_IMPORTED_MODULE_1__["HubConnectionBuilder"]().withUrl('library').build();
    };
    LibraryService.prototype.startConnection = function () {
        var _this = this;
        this._hubConnection
            .start()
            .then(function () {
            _this.connectionIsEstablished = true;
            console.log('Hub connection started');
            _this.connectionEstablished.emit(true);
        })
            .catch(function (err) {
            console.log('Error while establishing connection, retrying...');
            setTimeout(function () { return _this.startConnection(); }, 5000);
        });
    };
    LibraryService.prototype.registerOnServerEvents = function () {
        var _this = this;
        this._hubConnection.on('LibraryUpdate', function (data) {
            console.log(data);
            _this.updateNotificationReceived.emit(data);
        });
        var that = this;
        this._hubConnection.onclose(function () {
            console.log('Hub connection lost');
            that.connectionIsEstablished = false;
            that.startConnection();
        });
    };
    LibraryService.prototype.getBooks = function () {
        return this._hubConnection.invoke('GetBooks');
    };
    LibraryService.prototype.refreshLibrary = function () {
        return this._hubConnection.invoke('RefreshLibrary');
    };
    LibraryService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [])
    ], LibraryService);
    return LibraryService;
}());



/***/ }),

/***/ "./src/app/shared/update-notification.ts":
/*!***********************************************!*\
  !*** ./src/app/shared/update-notification.ts ***!
  \***********************************************/
/*! exports provided: UpdateNotification */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UpdateNotification", function() { return UpdateNotification; });
var __importDefault = (undefined && undefined.__importDefault) || function (mod) {
  return (mod && mod.__esModule) ? mod : { "default": mod };
};
var UpdateNotification = /** @class */ (function () {
    function UpdateNotification(init) {
        Object.assign(this, init);
    }
    return UpdateNotification;
}());



/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
var __importDefault = (undefined && undefined.__importDefault) || function (mod) {
  return (mod && mod.__esModule) ? mod : { "default": mod };
};
var environment = {
    production: false
};
/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! exports provided: getBaseUrl */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getBaseUrl", function() { return getBaseUrl; });
/* harmony import */ var hammerjs__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! hammerjs */ "./node_modules/hammerjs/hammer.js");
/* harmony import */ var hammerjs__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(hammerjs__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/__ivy_ngcc__/fesm5/core.js");
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/__ivy_ngcc__/fesm5/platform-browser-dynamic.js");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");
var __importDefault = (undefined && undefined.__importDefault) || function (mod) {
  return (mod && mod.__esModule) ? mod : { "default": mod };
};





function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
var providers = [
    { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] }
];
if (_environments_environment__WEBPACK_IMPORTED_MODULE_4__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_2__["platformBrowserDynamic"])(providers).bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_3__["AppModule"])
    .catch(function (err) { return console.log(err); });


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\Dev\AudiobookLibrary\AudiobookLibrary.Web\ClientApp\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map