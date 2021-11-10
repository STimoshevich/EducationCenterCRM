import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CommonService {
  constructor() {}

  ObjectToHttpParams(obj: any): HttpParams {
    let filterArray = Object.entries(obj as object).map(([key, value]) => ({
      key,
      value,
    }));

    let params = new HttpParams();
    for (let prop of filterArray) {
      if (prop.value) {
        params = params.append(prop.key, prop.value);
      }
    }
    return params;
  }

  PageCountCalculator(itemsAmount: number, itemsPerPage: number): number {
    return Math.ceil(itemsAmount / itemsPerPage);
  }
}
