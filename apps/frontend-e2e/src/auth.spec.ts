import { test, expect } from '@playwright/test';

test.describe('Frontend Login', () => {
    test('should display login form', async ({ page }) => {
        // Navigate to root first, it should redirect to login due to AuthGuard
        console.log('Navigating to /');
        await page.goto('/');
        console.log('Current URL:', page.url());

        // Check if we are redirected to /login
        await expect(page).toHaveURL(/.*\/login/);
        console.log('Redirected to /login successfully');

        // Check for elements
        await expect(page.locator('app-login h2')).toBeVisible({ timeout: 10000 });
        await expect(page.locator('input#username')).toBeVisible();
        await expect(page.locator('input#password')).toBeVisible();
        await expect(page.locator('button[type="submit"]')).toBeVisible();
    });

    test('should handle invalid login', async ({ page }) => {
        // Listen for console logs
        page.on('console', msg => console.log('BROWSER LOG:', msg.text()));

        console.log('Navigating to /login');
        await page.goto('/login');
        console.log('Current URL:', page.url());

        await page.fill('input#username', 'invalid');
        await page.fill('input#password', 'invalid');
        console.log('Clicking submit');
        await page.click('button[type="submit"]');

        await expect(page.locator('.error-message')).toBeVisible({ timeout: 10000 });
        await expect(page.locator('.error-message')).toContainText('Login failed');
    });
});
