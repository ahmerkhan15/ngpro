import { NgModule } from '@angular/core';
import { DataViewModule } from 'primeng/dataview';
import { PanelModule } from 'primeng/panel';
import { DialogModule } from 'primeng/dialog';
import { TabViewModule } from 'primeng/tabview';
import { CodeHighlighterModule } from 'primeng/codehighlighter';
import { CommonModule } from '@angular/common';
import {MessagesModule} from 'primeng/messages';
import {MessageModule} from 'primeng/message';
import {InputTextModule} from 'primeng/inputtext';
import {PasswordModule} from 'primeng/password';

@NgModule({
    imports: [InputTextModule,PasswordModule,DataViewModule,PanelModule,DialogModule,TabViewModule,CodeHighlighterModule,MessagesModule,MessagesModule,MessageModule],
    exports: [InputTextModule,PasswordModule,DataViewModule,DataViewModule,PanelModule,DialogModule,TabViewModule,CodeHighlighterModule,MessagesModule,MessageModule]
})
export class ngPrimeModule {

}
