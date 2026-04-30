# ?? BARCODE SCANNER TESTING GUIDE

## ?? How to Test Barcode Scanner Feature

### Step-by-Step Instructions:

1. **Launch the Application**
   - Run the SAIMS application
   - Login with any credentials

2. **Navigate to Sales**
   - Click on **Transactions** in the sidebar
   - Click on **Sales**

3. **Use Barcode Scanner Input**
   - The cursor will automatically focus on the **Barcode Scanner Input** field
   - Type any of the product codes below
   - Press **ENTER** key

4. **Watch the Magic!** ?
   - Product automatically added to cart
   - Quantity updates if product already in cart
   - Transaction summary updates in real-time
   - Input field clears for next scan

---

## ?? Test Barcodes (Product Codes)

| Barcode | Product Name                | Price   | Stock | Status          |
|---------|----------------------------|---------|-------|-----------------|
| **P001** | Coca Cola 1.5L             | ?55.00  | 150   | ? Available    |
| **P002** | Lucky Me Pancit Canton     | ?12.50  | 200   | ? Available    |
| **P003** | Argentina Corned Beef      | ?45.00  | 80    | ? Available    |
| **P004** | Red Horse Beer             | ?50.00  | 100   | ? Available    |
| **P005** | Payless White Sugar 1kg    | ?65.00  | 60    | ? Available    |
| **P006** | Champion Detergent         | ?8.50   | 120   | ? Available    |
| **P007** | San Miguel Pale Pilsen     | ?45.00  | 5     | ?? Low Stock    |
| **P008** | Del Monte Tomato Sauce     | ?18.00  | 90    | ? Available    |
| **P009** | Alaska Condensed Milk      | ?35.00  | 0     | ? Out of Stock |
| **P010** | Jack n Jill Piattos        | ?25.00  | 110   | ? Available    |

---

## ?? Testing Scenarios

### ? Scenario 1: Normal Product Scan
**Steps:**
1. Type: `P001`
2. Press: `ENTER`
3. **Result:** Coca Cola 1.5L added to cart (?55.00)

---

### ? Scenario 2: Multiple Same Products
**Steps:**
1. Type: `P002`
2. Press: `ENTER`
3. Type: `P002` again
4. Press: `ENTER`
5. **Result:** Quantity increases to 2, Total = ?25.00

---

### ? Scenario 3: Multiple Different Products
**Steps:**
1. Type: `P001` ? ENTER
2. Type: `P004` ? ENTER
3. Type: `P010` ? ENTER
4. **Result:** 
   - Coca Cola: ?55.00
   - Red Horse: ?50.00
   - Piattos: ?25.00
   - **Subtotal: ?130.00**

---

### ?? Scenario 4: Low Stock Warning
**Steps:**
1. Type: `P007`
2. Press: `ENTER`
3. **Result:** San Miguel Pale Pilsen added (Stock: 5 - Low Stock item)

---

### ? Scenario 5: Out of Stock
**Steps:**
1. Type: `P009`
2. Press: `ENTER`
3. **Result:** Error message - "Product 'Alaska Condensed Milk' is out of stock!"

---

### ? Scenario 6: Invalid Barcode
**Steps:**
1. Type: `P999`
2. Press: `ENTER`
3. **Result:** Error message - "Product with barcode 'P999' not found!"

---

## ?? Recommended Demo Flow

```
1. Scan P001 (Coca Cola)           ? ? Added
2. Scan P002 (Pancit Canton)       ? ? Added
3. Scan P002 again                  ? ? Quantity: 2
4. Scan P004 (Red Horse)           ? ? Added
5. Scan P010 (Piattos)             ? ? Added

Current Cart:
- Coca Cola 1.5L        (1x) = ?55.00
- Pancit Canton         (2x) = ?25.00
- Red Horse Beer        (1x) = ?50.00
- Piattos               (1x) = ?25.00

Subtotal: ?155.00

6. Enter Discount: 5
7. Total Amount: ?150.00
8. Payment Method: Cash
9. Amount Tendered: 200
10. Change: ?50.00

? Click "Save & Print"
```

---

## ?? Technical Details

### Barcode Input Field Features:
- **Auto-focus** on form load
- **Enter key** triggers barcode processing
- **Auto-clear** after successful scan
- **Error handling** for invalid/out-of-stock products
- **Case-insensitive** barcode matching

### Cart Features:
- **Auto-increment** quantity if product exists
- **Editable quantity** column
- **Auto-calculate** totals
- **Real-time** summary updates

### Transaction Summary:
- Total Items (count)
- Subtotal (sum of all items)
- Discount (manual input)
- **Total Amount** (Subtotal - Discount)
- Payment Method (dropdown)
- Amount Tendered (input)
- **Change** (auto-calculated)

---

## ??? Keyboard Shortcuts

| Key        | Action                              |
|------------|-------------------------------------|
| **ENTER**  | Process barcode scan                |
| **TAB**    | Move to next field                  |
| **ESC**    | (Optional: Future feature)          |

---

## ?? Visual Indicators

| Color       | Meaning              |
|-------------|----------------------|
| **Green**   | Available stock      |
| **Orange**  | Low stock warning    |
| **Red**     | Out of stock         |
| **Blue**    | Total amount display |

---

## ?? Integration Notes

### For Real Hardware Barcode Scanner:
- Most USB barcode scanners emulate keyboard input
- They automatically send ENTER after scanning
- No additional code changes needed
- Just plug and scan!

### Supported Scanner Types:
- ? USB Barcode Scanners (Keyboard Wedge)
- ? Handheld Laser Scanners
- ? 2D QR/Barcode Readers
- ? Bluetooth Barcode Scanners

---

## ?? Quick Test Commands

Copy and paste these in sequence (press ENTER after each):

```
P001
P002
P003
P004
P005
```

**Expected Result:**
5 products added to cart with a subtotal of ?212.50

---

## ? Troubleshooting

### Issue: Barcode not working
- **Solution:** Click on the barcode input field to focus
- Make sure you press ENTER after typing

### Issue: Product not found
- **Solution:** Use barcodes P001 to P010 only
- Check for typos (case-insensitive)

### Issue: Out of stock message
- **Solution:** P009 is intentionally out of stock for testing
- Use other product codes

---

## ?? Training Tips

1. **Start simple:** Scan one product at a time
2. **Test duplicates:** Scan same product twice
3. **Test errors:** Try invalid barcode (P999)
4. **Test out-of-stock:** Try P009
5. **Complete transaction:** Add discount, payment, calculate change
6. **Clear and repeat:** Use "Clear All" button

---

## ?? Sample Transaction Walkthrough

**Step 1:** Scan Products
- P001 ? Coca Cola (?55.00)
- P002 ? Pancit Canton (?12.50)
- P004 ? Red Horse (?50.00)

**Step 2:** Review Cart
- Total Items: 3
- Subtotal: ?117.50

**Step 3:** Apply Discount
- Discount: ?10.00
- Total Amount: ?107.50

**Step 4:** Payment
- Payment Method: Cash
- Amount Tendered: ?200.00
- Change: ?92.50

**Step 5:** Complete
- Click "Save & Print"
- Cart clears
- Ready for next customer

---

**?? PROTIP:** Keep the barcode input field focused at all times for quick scanning!

---

**?? SAIMS Barcode Scanner - Test Guide**  
*For presentation and demonstration purposes*
