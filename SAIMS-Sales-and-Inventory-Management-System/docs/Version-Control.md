# Version Control — Weekly Presentation Rollout

SAIMS is presented incrementally using Git tags as permanent snapshots. Each version
unlocks exactly one form/feature on top of the previous version. Forms not yet
presented show an "Under Construction" placeholder instead of their real content.

## Rollout Schedule

| Version | Feature Unlocked | Forms Unlocked | Forms Still Gated |
|---|---|---|---|
| v1.00 | Login / Forgot Password / Dashboard shell | `LoginForm`, `ForgotPasswordForm`, `MainDashboardForm` | `UsersForm`, `ProductsForm`, `CategoriesForm`, `StockInForm`, `StockOutForm`, `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |
| v1.01 | Admin: Users Management | + `UsersForm` | `ProductsForm`, `CategoriesForm`, `StockInForm`, `StockOutForm`, `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |
| v1.02 | Admin: Products Management | + `ProductsForm` | `CategoriesForm`, `StockInForm`, `StockOutForm`, `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |
| v1.03 | Admin: Categories Management | + `CategoriesForm` | `StockInForm`, `StockOutForm`, `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |
| v1.04 | Admin: Stock In | + `StockInForm` | `StockOutForm`, `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |
| v1.05 | Admin: Stock Out | + `StockOutForm` | `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |
| v1.06 | Admin: Inventory Report | + `InventoryReportForm` | `SalesForm`, `ReceiptsForm` |
| v1.07 | Cashier: Sales Transaction (POS) | + `SalesForm` | `ReceiptsForm` |
| v1.08 | Cashier: Receipts (Full System) | + `ReceiptsForm` | *(none — full system unlocked)* |

Note: unlike a two-portal (admin/patient) app, SAIMS has a single `MainDashboardForm`
shell whose Setup menu is hidden for non-admin roles (`ApplyRoleAccess` in
`MainDashboardForm.vb`). "Admin" rows above are the Setup/Reports forms; "Cashier"
rows are the Transactions forms available to all roles.

## The Under Construction Strategy

`Forms/UnderConstructionForm.vb` is the gate:

- `Public Const CURRENT_VERSION As String = "v1.00"` at the top — bumped once per version.
- Dark blue background (`#1A237E`), 🚧 emoji, orange "Current Version" label, white
  "Under Construction" title, and a "← Go Back" button that only calls `Me.Close()`
  (never `Application.Exit`, so the caller form can also close itself).

Every gated form has this block at the very top of its `Form_Load`:

```vb
Private Sub SomeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    ' GATE — remove this block when unlocking for vX.XX
    Dim gate As New UnderConstructionForm()
    gate.ShowDialog()
    Me.Close()
    Return
    ' END GATE

    ' ... real form code below (unchanged) ...
End Sub
```

Showing the gate as a modal dialog, then closing the calling form once it returns,
means the real form body below the gate never executes while locked — no other
changes to the form's logic are needed.

## Git Commands Per Version

```bash
# Stage and commit only the files touched by this version's unlock
git add <UnlockedForm.vb> Forms/UnderConstructionForm.vb
git commit -m "feat: implement vX.XX - unlock [Feature Name]"

# Tag the commit and push both
git tag vX.XX
git push origin main
git push origin vX.XX
```

### How Git Tags Work

A tag is a permanent, named pointer to a specific commit. Unlike branches, tags
don't move — `git checkout v1.03` always returns exactly the state of the project
as of the v1.03 presentation, regardless of what happens on `main` afterward. This
is what lets old presentation snapshots be revisited later without special
branches.

## GitHub Release Tags

Fill in the commit hash column after all versions have been tagged and pushed,
using:

```bash
git tag | sort | xargs -I{} git log -1 --format="{} %H" {}
```

| Version | Tag | Commit Hash |
|---|---|---|
| v1.00 | `v1.00` | *(fill in)* |
| v1.01 | `v1.01` | *(fill in)* |
| v1.02 | `v1.02` | *(fill in)* |
| v1.03 | `v1.03` | *(fill in)* |
| v1.04 | `v1.04` | *(fill in)* |
| v1.05 | `v1.05` | *(fill in)* |
| v1.06 | `v1.06` | *(fill in)* |
| v1.07 | `v1.07` | *(fill in)* |
| v1.08 | `v1.08` | *(fill in)* |

## When a Prof or Client Requests Changes After a Presentation

Fix the issue on `main`, then move the affected version's tag to point at the fix
so the "snapshot" for that version reflects the corrected state:

```bash
# Fix on main first
git checkout main
git add .
git commit -m "feat: update [form] per feedback"
git push origin main

# Delete old tag and re-create it pointing to the new commit
git tag -d vX.XX
git push origin :refs/tags/vX.XX
git tag vX.XX
git push origin vX.XX
```

Only move the tag for the version actually being corrected — earlier tags stay
untouched so previously presented snapshots remain reproducible.
