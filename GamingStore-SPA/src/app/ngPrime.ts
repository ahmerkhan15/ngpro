import { NgModule } from '@angular/core';
import { DataViewModule } from 'primeng/dataview';
import { PanelModule } from 'primeng/panel';
import { DialogModule } from 'primeng/dialog';
import { TabViewModule } from 'primeng/tabview';
import { CodeHighlighterModule } from 'primeng/codehighlighter';
import { CommonModule } from '@angular/common';

@NgModule({
    imports: [DataViewModule,
        PanelModule,
        DialogModule,
        TabViewModule,
        CodeHighlighterModule],
    exports: [DataViewModule,DataViewModule,
        PanelModule,
        DialogModule,
        TabViewModule,
        CodeHighlighterModule]
})
export class ngPrimeModule {

}
