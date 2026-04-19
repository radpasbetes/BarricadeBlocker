# BarricadeBlocker
Block barricades on vehicles with whitelist.

## Config
```html
<?xml version="1.0" encoding="utf-8"?>
<Configuration xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <SendWarning>true</SendWarning>
  <WarningMessage>Blocked!</WarningMessage>
  <AllowedBarricadeIDs>
    <unsignedShort>24347</unsignedShort>
    <unsignedShort>1470</unsignedShort>
    <unsignedShort>24353</unsignedShort>
  </AllowedBarricadeIDs>
  <AdminBypass>false</AdminBypass>
</Configuration>
```
