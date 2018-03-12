
using System;
using System.Runtime.InteropServices;
namespace gvimwrapper {
partial class wrapper {

	const int WM_ACTIVATE = 6;
	const int WA_INACTIVE = 0;
	const int WA_ACTIVE = 1;
	const int WA_CLICKACTIVE = 2;

	const int GWL_HWNDPARENT = -8;
	const int GWL_ID = -12;
	const int GWL_STYLE = -16;
	const int GWL_EXSTYLE = -20;

	// Window Styles 
	const UInt32 WS_OVERLAPPED = 0;
	const UInt32 WS_POPUP = 0x80000000;
	const UInt32 WS_CHILD = 0x40000000;
	const UInt32 WS_MINIMIZE = 0x20000000;
	const UInt32 WS_VISIBLE = 0x10000000;
	const UInt32 WS_DISABLED = 0x8000000;
	const UInt32 WS_CLIPSIBLINGS = 0x4000000;
	const UInt32 WS_CLIPCHILDREN = 0x2000000;
	const UInt32 WS_MAXIMIZE = 0x1000000;
	const UInt32 WS_CAPTION = 0xC00000;      // WS_BORDER or WS_DLGFRAME  
	const UInt32 WS_BORDER = 0x800000;
	const UInt32 WS_DLGFRAME = 0x400000;
	const UInt32 WS_VSCROLL = 0x200000;
	const UInt32 WS_HSCROLL = 0x100000;
	const UInt32 WS_SYSMENU = 0x80000;
	const UInt32 WS_THICKFRAME = 0x40000;
	const UInt32 WS_GROUP = 0x20000;
	const UInt32 WS_TABSTOP = 0x10000;
	const UInt32 WS_MINIMIZEBOX = 0x20000;
	const UInt32 WS_MAXIMIZEBOX = 0x10000;
	const UInt32 WS_TILED = WS_OVERLAPPED;
	const UInt32 WS_ICONIC = WS_MINIMIZE;
	const UInt32 WS_SIZEBOX = WS_THICKFRAME;

	// Extended Window Styles 
	const UInt32 WS_EX_DLGMODALFRAME = 0x0001;
	const UInt32 WS_EX_NOPARENTNOTIFY = 0x0004;
	const UInt32 WS_EX_TOPMOST = 0x0008;
	const UInt32 WS_EX_ACCEPTFILES = 0x0010;
	const UInt32 WS_EX_TRANSPARENT = 0x0020;
	const UInt32 WS_EX_MDICHILD = 0x0040;
	const UInt32 WS_EX_TOOLWINDOW = 0x0080;
	const UInt32 WS_EX_WINDOWEDGE = 0x0100;
	const UInt32 WS_EX_CLIENTEDGE = 0x0200;
	const UInt32 WS_EX_CONTEXTHELP = 0x0400;
	const UInt32 WS_EX_RIGHT = 0x1000;
	const UInt32 WS_EX_LEFT = 0x0000;
	const UInt32 WS_EX_RTLREADING = 0x2000;
	const UInt32 WS_EX_LTRREADING = 0x0000;
	const UInt32 WS_EX_LEFTSCROLLBAR = 0x4000;
	const UInt32 WS_EX_RIGHTSCROLLBAR = 0x0000;
	const UInt32 WS_EX_CONTROLPARENT = 0x10000;
	const UInt32 WS_EX_STATICEDGE = 0x20000;
	const UInt32 WS_EX_APPWINDOW = 0x40000;
	const UInt32 WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE);
	const UInt32 WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST);
	const UInt32 WS_EX_LAYERED = 0x00080000;
	const UInt32 WS_EX_NOINHERITLAYOUT = 0x00100000; // Disable inheritence of mirroring by children
	const UInt32 WS_EX_LAYOUTRTL = 0x00400000; // Right to left mirroring
	const UInt32 WS_EX_COMPOSITED = 0x02000000;
	const UInt32 WS_EX_NOACTIVATE = 0x08000000;

	const UInt32 SWP_NOSIZE = 0x0001;
	const UInt32 SWP_NOMOVE = 0x0002;
	const UInt32 SWP_NOZORDER = 0x0004;
	const UInt32 SWP_NOREDRAW = 0x0008;
	const UInt32 SWP_NOACTIVATE = 0x0010;
	const UInt32 SWP_DRAWFRAME = 0x0020;
	const UInt32 SWP_FRAMECHANGED = 0x0020;
	const UInt32 SWP_SHOWWINDOW = 0x0040;
	const UInt32 SWP_HIDEWINDOW = 0x0080;
	const UInt32 SWP_NOCOPYBITS = 0x0100;
	const UInt32 SWP_NOOWNERZORDER = 0x0200;
	const UInt32 SWP_NOREPOSITION = 0x0200;
	const UInt32 SWP_NOSENDCHANGING = 0x0400;
	const UInt32 SWP_DEFERERASE = 0x2000;
	const UInt32 SWP_ASYNCWINDOWPOS = 0x4000;

	const UInt32 WM_SYSCOMMAND = 0x112;
	const UInt32 SC_MAXIMIZE = 0xF030;
	const UInt32 SC_MINIMIZE = 0xF020;
	const UInt32 SC_RESTORE  = 0xF050;

	[DllImport("user32.dll")]
	static extern int SetWindowLong(
		IntPtr hWnd,
		int nIndex,
		uint dwNewLong
	);

	[DllImport("user32.dll")]
	static extern uint GetWindowLong(
		IntPtr hWnd,
		int nIndex
	);

	[DllImport("user32.dll")]
	static extern bool SetWindowPos(
		IntPtr hWnd,
		IntPtr hWndInsertAfter,
		int X,
		int Y,
		int cx,
		int cy,
		UInt32 uFlags
	);

	[DllImport("user32.dll")]
	static extern IntPtr SetParent(
		IntPtr hWndChild,
		IntPtr hWndNewParent
	);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	static extern IntPtr SendMessage(
		IntPtr hWnd,
		UInt32 Msg,
		IntPtr wParam,
		IntPtr lParam
	);

	[DllImport("user32.dll")]
	static extern int SetForegroundWindow(IntPtr point);

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////