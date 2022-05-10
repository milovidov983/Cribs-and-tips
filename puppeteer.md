**Get all html**

const data = await page.evaluate(() => document.querySelector('*').outerHTML);

**Get data from meta**

const img = await page.evaluate(() => document.querySelector('meta[property="og:image"]').content);
