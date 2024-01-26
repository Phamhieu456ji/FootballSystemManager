import { FastConnectFootballSystemTemplatePage } from './app.po';

describe('FastConnectFootballSystem App', function() {
  let page: FastConnectFootballSystemTemplatePage;

  beforeEach(() => {
    page = new FastConnectFootballSystemTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
