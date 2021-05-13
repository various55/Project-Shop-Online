/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';

    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = '/Content/ckfinder_aspnet_2.6.2.1/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Content/ckfinder_aspnet_2.6.2.1/ckfinder/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/Content/ckfinder_aspnet_2.6.2.1/ckfinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/Content/ckfinder_aspnet_2.6.2.1/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Images';
    config.filebrowserFlashUploadUrl = '/Content/ckfinder_aspnet_2.6.2.1/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    CKFinder.setupCKEditor(null, '/Content/ckfinder_aspnet_2.6.2.1/ckfinder/');
};
