import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe, formatDate } from '@angular/common';

import { Constants } from 'src/app/utils/constants';

@Pipe({
  name: 'DateFormatPipe'
})
export class DateTimeFormatPipe extends DatePipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return super.transform(value, `${Constants.DATE_TIME_FORMAT}`);
  }

}
